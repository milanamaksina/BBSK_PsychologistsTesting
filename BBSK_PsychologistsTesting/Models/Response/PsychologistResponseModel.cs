using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BBSK_PsychologistsTesting.Models.Response
{
    public class PsychologistResponseModel
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("lastName")]
        public string LastName { get; set; }

        [JsonPropertyName("patronymic")]
        public string Patronymic { get; set; }

        [JsonPropertyName("gender")]
        public int Gender { get; set; }

        [JsonPropertyName("birthDate")]
        public DateTime BirthDate { get; set; }

        [JsonPropertyName("phone")]
        public string Phone { get; set; }

        [JsonPropertyName("password")]
        public string Password { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("workExperience")]
        public int? WorkExperience { get; set; }

        [JsonPropertyName("pasportData")]
        public string PasportData { get; set; }

        [JsonPropertyName("education")]
        public List<string> Education { get; set; }

        [JsonPropertyName("checkStatus")]
        public int CheckStatus { get; set; }

        [JsonPropertyName("therapyMethods")]
        public List<string> TherapyMethods { get; set; }

        [JsonPropertyName("problems")]
        public List<string> Problems { get; set; }

        [JsonPropertyName("price")]
        public decimal Price { get; set; }

        [JsonPropertyName("isDeleted")]
        public bool IsDeleted { get; set; }

        public override bool Equals(object? obj)
        {
            bool flag = true;
            if (obj == null || !(obj is PsychologistResponseModel))
            {
                flag = false;
            }
            else
            {
                PsychologistResponseModel model = (PsychologistResponseModel)obj;
                if (model.Id != this.Id ||
                    model.Name != this.Name ||
                    model.LastName != this.LastName ||
                    model.Patronymic != this.Patronymic ||
                    model.Gender != this.Gender ||
                    model.BirthDate != this.BirthDate ||
                    model.Phone != this.Phone ||
                    model.Password != this.Password ||
                    model.Email != this.Email ||
                    model.WorkExperience != this.WorkExperience ||
                    model.PasportData != this.PasportData ||
                    model.Education != this.Education ||
                    model.CheckStatus != this.CheckStatus ||
                    model.TherapyMethods != this.TherapyMethods ||
                    model.Problems != this.Problems ||
                    model.Price != this.Price ||
                    model.IsDeleted != this.IsDeleted
                    )
                {
                    flag = false;
                }
            }
            return flag;
        }
    }
}
