using BBSK_PsychologistsTesting.Models.Request;
using System.Net.Http;
using System.Text;
using System.Text.Json;

namespace BBSK_PsychologistsTesting.Clients
{
    public class CommentsClient
    {
        public HttpResponseMessage AddCommentToPsychologist(int psychologistId, CommentAddingRequestModel model)
        {
            string json = JsonSerializer.Serialize(model);
            int id = psychologistId;

            HttpClient comment = new HttpClient();
            HttpRequestMessage message = new HttpRequestMessage()
            {
                Method = HttpMethod.Post,
                RequestUri = new System.Uri($"{Urls.Psychologists}/{id}/comments"),
                Content = new StringContent(json, Encoding.UTF8, "application/json")
            };

            return comment.Send(message);
        }
    }
}
