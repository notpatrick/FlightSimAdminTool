using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using DatabaseClient.Pages;
using Newtonsoft.Json;

namespace DatabaseClient
{
    public class WebConnection
    {
        public static string ServerUrl = "http://localhost:1337";

        #region UserRoutes

        public static async Task CreateNewUser(User newUser)
        {
            using (var client = new HttpClient())
            {
                var response = await client.PostAsync(ServerUrl + "/user", UserToContent(newUser));

                //var responseString = await response.Content.ReadAsStringAsync();
            }
        }

        public static async Task DeleteUser(int id)
        {
            using (var client = new HttpClient())
            {
                var response = await client.DeleteAsync(ServerUrl + "/user/" + id);
            }
        }

        public static async Task<List<User>> GetAllUsers()
        {
            List<User> result;
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(ServerUrl + "/users");
                response.EnsureSuccessStatusCode();

                var x = await response.Content.ReadAsStringAsync();
                result = JsonConvert.DeserializeObject<List<User>>(x);
            }
            return result;
        }

        #endregion

        #region GameStateRoutes

        public static async Task<List<GameState>> GetAllGameStates()
        {
            List<GameState> result;
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(ServerUrl + "/state");
                response.EnsureSuccessStatusCode();

                var x = await response.Content.ReadAsStringAsync();
                result = JsonConvert.DeserializeObject<List<GameState>>(x);
            }
            return result;
        }

        public static async Task CreateNewGameState(GameState state)
        {
            using (var client = new HttpClient())
            {
                var response = await client.PostAsync(ServerUrl + "/save", GameStateToContent(state));

                //var responseString = await response.Content.ReadAsStringAsync();
            }
        }

        public static async Task DeleteGameState(int id)
        {
            using (var client = new HttpClient())
            {
                var response = await client.DeleteAsync(ServerUrl + "/state/" + id);
            }
        }

        #endregion

        #region Helpers

        public static FormUrlEncodedContent UserToContent(User user)
        {
            var pairs = new Dictionary<string, string>
            {
                {"name", user.Name},
                {"password", user.Password}
            };

            return new FormUrlEncodedContent(pairs);
        }

        public static FormUrlEncodedContent GameStateToContent(GameState state)
        {
            var pairs = new Dictionary<string, string>
            {
                {"id", state.Id.ToString()},
                {"userID", state.UserId.ToString()},
                {"score", state.Score.ToString()},
                {"isRunning", state.IsRunning ? "1" : "0"},
                {"locationName", state.LocationName},
                {"positionX", state.PositionX.ToString()},
                {"positionY", state.PositionY.ToString()},
                {"speedX", state.SpeedX.ToString()},
                {"speedY", state.SpeedY.ToString()},
            };

            return new FormUrlEncodedContent(pairs);
        }

        #endregion
    }
}