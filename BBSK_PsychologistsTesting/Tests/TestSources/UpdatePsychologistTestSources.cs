using BBSK_PsychologistsTesting.Models.Request;
using System;
using System.Collections;
using System.Collections.Generic;

namespace BBSK_PsychologistsTesting.Tests.TestSources
{
    public class UpdatePsychologistTestSources
    {
        public class PsychologistUpdate_WhenPsychologistModelIsCorrect_TestSource : IEnumerable
        {
            public IEnumerator GetEnumerator()
            {
                yield return new PsychologistRequestModel()
                {
                    Name = "Валерий",
                    LastName = "Александрович",
                    Patronymic = "Нежный",
                    Gender = 1,
                    BirthDate = new DateTime(2022, 05, 01),
                    Phone = "89992314543",
                    Password = "Azino777",
                    Email = "valera@mail.ru",
                    WorkExperience = 5,
                    PasportData = "4015 2453443 ГУ МВД ПО СПБ",
                    Education = new List<string> { "Мгу" },
                    CheckStatus = 1,
                    TherapyMethods = new List<string> { "когнитивная терапия" },
                    Problems = new List<string> { "тревога" },
                    Price = 1000
                };


            }
        }
    }
}
