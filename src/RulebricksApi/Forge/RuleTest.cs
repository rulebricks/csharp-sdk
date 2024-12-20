using System;
using System.Collections.Generic;
using System.Text.Json;

namespace RulebricksApi.Forge
{
    public class RuleTest
    {
        public string Id { get; private set; }
        public string Name { get; private set; }
        public Dictionary<string, object> Request { get; private set; }
        public Dictionary<string, object> Response { get; private set; }
        public bool Critical { get; private set; }
        public DateTime? LastExecuted { get; private set; }
        public string TestState { get; private set; }
        public string Error { get; private set; }
        public bool? Success { get; private set; }

        public RuleTest()
        {
            Id = GenerateId();
            Name = "Untitled Test";
            Request = new Dictionary<string, object>();
            Response = new Dictionary<string, object>();
            Critical = false;
        }

        public RuleTest SetName(string name)
        {
            Name = name;
            return this;
        }

        public RuleTest Expect(Dictionary<string, object> request, Dictionary<string, object> response)
        {
            Request = request;
            Response = response;
            return this;
        }

        public RuleTest IsCritical(bool critical = true)
        {
            Critical = critical;
            return this;
        }

        private string GenerateId(int length = 21)
        {
            const string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random();
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public Dictionary<string, object> ToDict()
        {
            return new Dictionary<string, object>
            {
                { "id", Id },
                { "name", Name },
                { "request", Request },
                { "response", Response },
                { "critical", Critical },
                { "lastExecuted", LastExecuted },
                { "testState", TestState },
                { "error", Error },
                { "success", Success }
            };
        }

        public static RuleTest FromJson(string jsonString)
        {
            var data = JsonSerializer.Deserialize<Dictionary<string, JsonElement>>(jsonString);
            return FromDict(data);
        }

        public static RuleTest FromDict(Dictionary<string, JsonElement> data)
        {
            var test = new RuleTest();

            if (data.TryGetValue("id", out var id))
                test.Id = id.GetString() ?? test.GenerateId();

            if (data.TryGetValue("name", out var name))
                test.Name = name.GetString() ?? "Untitled Test";

            if (data.TryGetValue("request", out var request))
                test.Request = JsonSerializer.Deserialize<Dictionary<string, object>>(request.GetRawText());

            if (data.TryGetValue("response", out var response))
                test.Response = JsonSerializer.Deserialize<Dictionary<string, object>>(response.GetRawText());

            if (data.TryGetValue("critical", out var critical))
                test.Critical = critical.GetBoolean();

            if (data.TryGetValue("lastExecuted", out var lastExecuted) && lastExecuted.ValueKind != JsonValueKind.Null)
                test.LastExecuted = lastExecuted.GetDateTime();

            if (data.TryGetValue("testState", out var testState))
                test.TestState = testState.GetString();

            if (data.TryGetValue("error", out var error))
                test.Error = error.GetString();

            if (data.TryGetValue("success", out var success) && success.ValueKind != JsonValueKind.Null)
                test.Success = success.GetBoolean();

            return test;
        }
    }
}
