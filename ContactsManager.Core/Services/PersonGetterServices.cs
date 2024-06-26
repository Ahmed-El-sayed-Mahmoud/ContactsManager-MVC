﻿using Entities;
using Entities.Enums;
using Exceptions;
using Microsoft.Extensions.Logging;
using OfficeOpenXml;
using RepositoryContracts;
using Serilog;
using SerilogTimings;
using ServiceContracts;
using ServiceContracts.DTO;
using Services.ValidationHelpers;
using System;
using System.ComponentModel;
using LicenseContext = OfficeOpenXml.LicenseContext;

namespace Services
{
    public class PersonGetterServices : IPersonGetterServices
    {
        private readonly IPersonRepository _personsRepository;
        private readonly ILogger<PersonGetterServices> _logger;
        private readonly IDiagnosticContext _diagnosticContext;
        public PersonGetterServices(IPersonRepository personRepository,ILogger<PersonGetterServices>logger
            , IDiagnosticContext diagnosticContext)
        {
            _personsRepository = personRepository;
            _logger = logger;
            _diagnosticContext = diagnosticContext;
        }

        public async Task<List<PersonResponse>> GetAllPeople()
        {
            List<Person> persons;
            using (Operation.Time("Time Taken for Getting from DataBase"))
            {
                // return _db.sp_GetAllPersons().Select(temp=>temp.ToPersonResponse()).ToList();
                persons = await _personsRepository.GetAllPeople();
            }

           return persons.Select(t=>t.ToPersonResponse()).ToList();
        }
        public async Task<List<PersonResponse>> GetFiltered(string? SearchString, string? SearchBy)
        {
            //_logger.LogDebug("Get filtered Personservices is reached");
            if(string.IsNullOrWhiteSpace(SearchString))
                SearchString=string.Empty;
            SearchString = SearchString?.Trim();
            List<Person> list;
            using (Operation.Time("Time Taken for Getting from DataBase"))
            {


                list = SearchBy switch
                {
                    nameof(PersonResponse.PersonName) => await _personsRepository.GetFiltered(t =>
                    t.PersonName.Contains(SearchString)),

                    nameof(PersonResponse.Email) => await _personsRepository.GetFiltered(t =>
                    t.Email.Contains(SearchString)),

                    nameof(PersonResponse.DateOfBirth) => await _personsRepository.GetFiltered(t =>
                    t.DateOfBirth.Value.ToString("dd MMMM yyyy").Contains(SearchString)),

                    nameof(PersonResponse.Address) => await _personsRepository.GetFiltered(t =>
                    t.Address.Contains(SearchString)),

                    nameof(PersonResponse.Gender) => await _personsRepository.GetFiltered(t =>
                    t.Gender.Contains(SearchString)),

                    nameof(PersonResponse.Country) => await _personsRepository.GetFiltered(t =>
                    t.Country.Contains(SearchString)),

                    _ => await _personsRepository.GetAllPeople()
                };
            }
            _diagnosticContext.Set("Persons", list);
            return list.Select(t => t.ToPersonResponse()).ToList();
            
        }

        public async Task<PersonResponse?> GetPersonById(Guid? ID)
        {
            if (ID == null || ID == Guid.Empty) throw new ArgumentNullException("Id is Null");
            return (await _personsRepository.GetPersonById( ID.Value))?.ToPersonResponse();
        }

        public async Task<List<PersonResponse>> GetSortedPersons(List<PersonResponse> allPersons, string sortBy, SortOrderOptions sortOrder)
        {
            if (string.IsNullOrEmpty(sortBy))
                return allPersons;

            List<PersonResponse> sortedPersons = (sortBy, sortOrder) switch
            {
                (nameof(PersonResponse.PersonName), SortOrderOptions.ASC) => allPersons.OrderBy(temp => temp.PersonName, StringComparer.OrdinalIgnoreCase).ToList(),

                (nameof(PersonResponse.PersonName), SortOrderOptions.DESC) => allPersons.OrderByDescending(temp => temp.PersonName, StringComparer.OrdinalIgnoreCase).ToList(),

                (nameof(PersonResponse.Email), SortOrderOptions.ASC) => allPersons.OrderBy(temp => temp.Email, StringComparer.OrdinalIgnoreCase).ToList(),

                (nameof(PersonResponse.Email), SortOrderOptions.DESC) => allPersons.OrderByDescending(temp => temp.Email, StringComparer.OrdinalIgnoreCase).ToList(),

                (nameof(PersonResponse.DateOfBirth), SortOrderOptions.ASC) => allPersons.OrderBy(temp => temp.DateOfBirth).ToList(),

                (nameof(PersonResponse.DateOfBirth), SortOrderOptions.DESC) => allPersons.OrderByDescending(temp => temp.DateOfBirth).ToList(),

                (nameof(PersonResponse.Age), SortOrderOptions.ASC) => allPersons.OrderBy(temp => temp.Age).ToList(),

                (nameof(PersonResponse.Age), SortOrderOptions.DESC) => allPersons.OrderByDescending(temp => temp.Age).ToList(),

                (nameof(PersonResponse.Gender), SortOrderOptions.ASC) => allPersons.OrderBy(temp => temp.Gender.ToString(), StringComparer.OrdinalIgnoreCase).ToList(),

                (nameof(PersonResponse.Gender), SortOrderOptions.DESC) => allPersons.OrderByDescending(temp => temp.Gender.ToString(), StringComparer.OrdinalIgnoreCase).ToList(),

                (nameof(PersonResponse.Country), SortOrderOptions.ASC) => allPersons.OrderBy(temp => temp.Country, StringComparer.OrdinalIgnoreCase).ToList(),

                (nameof(PersonResponse.Country), SortOrderOptions.DESC) => allPersons.OrderByDescending(temp => temp.Country, StringComparer.OrdinalIgnoreCase).ToList(),

                (nameof(PersonResponse.Address), SortOrderOptions.ASC) => allPersons.OrderBy(temp => temp.Address, StringComparer.OrdinalIgnoreCase).ToList(),

                (nameof(PersonResponse.Address), SortOrderOptions.DESC) => allPersons.OrderByDescending(temp => temp.Address, StringComparer.OrdinalIgnoreCase).ToList(),

                (nameof(PersonResponse.ReceiveNewsLetters), SortOrderOptions.ASC) => allPersons.OrderBy(temp => temp.ReceiveNewsLetters).ToList(),

                (nameof(PersonResponse.ReceiveNewsLetters), SortOrderOptions.DESC) => allPersons.OrderByDescending(temp => temp.ReceiveNewsLetters).ToList(),

                _ => allPersons
            };

            return sortedPersons;
        }

        public async Task<MemoryStream> GetPersonsExcel()
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            MemoryStream memoryStream = new MemoryStream();
            using (var package = new ExcelPackage(memoryStream))
            {
                ExcelWorksheet workSheet = package.Workbook.Worksheets.Add("Persons Sheet");
                workSheet.Cells["A1"].Value = "Person Name";
                workSheet.Cells["B1"].Value = "Email";
                workSheet.Cells["C1"].Value = "Date of Birth";
                workSheet.Cells["D1"].Value = "Age";
                workSheet.Cells["E1"].Value = "Gender";
                workSheet.Cells["F1"].Value = "Country";
                workSheet.Cells["G1"].Value = "Address";
                workSheet.Cells["H1"].Value = "Receive News Letters";
                workSheet.Cells["A1:H1"].Style.Fill.SetBackground(System.Drawing.Color.Gray);
                workSheet.Cells.Style.HorizontalAlignment=OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                List<PersonResponse> persons = (await _personsRepository.GetAllPeople()).Select(t => t.ToPersonResponse()).ToList();
                int cur_row = 2;
                foreach(PersonResponse personResponse in persons)
                {
                    workSheet.Cells[cur_row, 1].Value = personResponse.PersonName;
                    workSheet.Cells[cur_row, 2].Value = personResponse.Email;
                    if (personResponse.DateOfBirth.HasValue)
                        workSheet.Cells[cur_row, 3].Value = personResponse.DateOfBirth.Value.ToString("yyyy-MM-dd");
                    workSheet.Cells[cur_row, 4].Value = personResponse.Age;
                    workSheet.Cells[cur_row, 5].Value = personResponse.Gender;
                    workSheet.Cells[cur_row, 6].Value = personResponse.Country;
                    workSheet.Cells[cur_row, 7].Value = personResponse.Address;
                    workSheet.Cells[cur_row, 8].Value = personResponse.ReceiveNewsLetters;
                    cur_row++;
                }
                workSheet.Cells["A1:H1"].AutoFitColumns();
                await package.SaveAsync();
            }
            memoryStream.Position = 0;
            return memoryStream;
        }

    }
}
