using BBSK_PsychologistsTesting.Models.Request;
using BBSK_PsychologistsTesting.Models.Response;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBSK_PsychologistsTesting.Tests.TestSources
{
    public class DeletePsychologistByIdTestSources
    {
        public class PsychologistDelete_WhenPsychologistModelIsDeleted_TestSource : IEnumerable
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
                    Price = 1000,
                    IsDeleted = false
                };

                yield return new List<PsychologistResponseModel>()
                {
                    new PsychologistResponseModel() { Name = "Михаил",
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
                    Price = 1000,
                    IsDeleted = false
                    },

                    new PsychologistResponseModel() { Name = "Геннадий",
                    LastName = "Витальевич",
                    Patronymic = "Козлов",
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
                    Price = 1000,
                    IsDeleted = false
                    },

                    new PsychologistResponseModel() { Name = "Анна",
                    LastName = "Александровна",
                    Patronymic = "Родионова",
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
                    Price = 1000,
                    IsDeleted = true
                    }
                };
            }
        }
    }
}
