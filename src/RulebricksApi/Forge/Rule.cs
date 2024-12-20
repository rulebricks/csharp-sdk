using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text.Json;
using System.Linq;
using RulebricksApi.Forge.Types;
using RulebricksApi.Forge.Fields;

namespace RulebricksApi.Forge
{
    public class Rule
    {
        private readonly RulebricksApiClient? _workspace;
        private readonly Dictionary<string, Field> _requestFields = new();
        private readonly Dictionary<string, Field> _responseFields = new();
        internal readonly List<Dictionary<string, object>> _conditions = new();
        private readonly List<RuleTest> _testSuite = new();
        private readonly List<string> _accessGroups = new();

        public string Id { get; private set; } = string.Empty;
        public string Name { get; private set; } = string.Empty;
        public string Description { get; private set; } = string.Empty;
        public string Slug { get; private set; } = string.Empty;
        public string? FolderId { get; private set; }
        public bool Published { get; private set; }
        public string? PublishedAt { get; private set; }
        public string CreatedAt { get; private set; } = string.Empty;
        public string UpdatedAt { get; private set; } = string.Empty;
        public string UpdatedBy { get; private set; } = string.Empty;

        public Rule(RulebricksApiClient? workspace = null)
        {
            _workspace = workspace;
            Id = Guid.NewGuid().ToString();
            Name = "Untitled Rule";
            Description = "";
            Slug = GenerateSlug();
            CreatedAt = DateTime.UtcNow.ToString("O");
            UpdatedAt = CreatedAt;
            UpdatedBy = "Rulebricks Forge SDK";
        }

        public Rule SetWorkspace(RulebricksApiClient client)
        {
            _workspace = client;
            return this;
        }

        public Rule SetName(string name)
        {
            Name = name;
            return this;
        }

        public Rule SetDescription(string description)
        {
            Description = description;
            return this;
        }

        public Rule SetFolderId(string folderId)
        {
            FolderId = folderId;
            return this;
        }

        public async Task<Rule> SetFolder(string folderName, bool createIfMissing = false)
        {
            if (_workspace == null)
                throw new InvalidOperationException("A Rulebricks client is required to set a folder by name");

            var folders = await _workspace.Assets.ListFoldersAsync();
            var folder = folders.FirstOrDefault(f => f.Name == folderName);

            if (folder == null && createIfMissing)
            {
                if (folders.Any(f => f.Name == folderName))
                    throw new InvalidOperationException("Folder name conflicts with an existing folder");
                var response = await _workspace.Assets.UpsertFolderAsync(new UpsertFolderRequest { Name = folderName });
                folder = new ListFoldersResponseItem { Id = response.Id, Name = response.Name };
            }

            if (folder == null)
                throw new InvalidOperationException($"Folder '{folderName}' not found and createIfMissing is false");

            FolderId = folder.Id;
            return this;
        }

        public BooleanField AddBooleanField(string name, string description = "", bool defaultValue = false)
        {
            var field = new BooleanField(name, description, defaultValue);
            _requestFields[name] = field;
            return field;
        }

        public NumberField AddNumberField(string name, string description = "", double defaultValue = 0)
        {
            var field = new NumberField(name, description, defaultValue);
            _requestFields[name] = field;
            return field;
        }

        public StringField AddStringField(string name, string description = "", string defaultValue = "")
        {
            var field = new StringField(name, description, defaultValue);
            _requestFields[name] = field;
            return field;
        }

        public DateField AddDateField(string name, string description = "", DateTime? defaultValue = null)
        {
            var field = new DateField(name, description, defaultValue);
            _requestFields[name] = field;
            return field;
        }

        public ListField AddListField(string name, string description = "", IEnumerable<object>? defaultValue = null)
        {
            var field = new ListField(name, description, defaultValue ?? new List<object>());
            _requestFields[name] = field;
            return field;
        }

        public BooleanField AddBooleanResponse(string name, string description = "", bool defaultValue = false)
        {
            var field = new BooleanField(name, description, defaultValue);
            _responseFields[name] = field;
            return field;
        }

        public NumberField AddNumberResponse(string name, string description = "", double defaultValue = 0)
        {
            var field = new NumberField(name, description, defaultValue);
            _responseFields[name] = field;
            return field;
        }

        public StringField AddStringResponse(string name, string description = "", string defaultValue = "")
        {
            var field = new StringField(name, description, defaultValue);
            _responseFields[name] = field;
            return field;
        }

        public DateField AddDateResponse(string name, string description = "", DateTime? defaultValue = null)
        {
            var field = new DateField(name, description, defaultValue);
            _responseFields[name] = field;
            return field;
        }

        public ListField AddListResponse(string name, string description = "", IEnumerable<object>? defaultValue = null)
        {
            var field = new ListField(name, description, defaultValue ?? new List<object>());
            _responseFields[name] = field;
            return field;
        }

        public async Task<Rule> Update()
        {
            if (_workspace == null)
                throw new InvalidOperationException("A Rulebricks client is required to push a rule to the workspace");

            await _workspace.Assets.ImportRuleAsync(new ImportRuleRequest { Rule = ToDict() });
            var updatedRule = await FromWorkspace(Id);
            return updatedRule;
        }

        public async Task<Rule> Publish()
        {
            if (_workspace == null)
                throw new InvalidOperationException("A Rulebricks client is required to publish a rule");

            var ruleDict = ToDict();
            ruleDict["_publish"] = true;
            await _workspace.Assets.ImportRuleAsync(new ImportRuleRequest { Rule = ruleDict });
            var publishedRule = await FromWorkspace(Id);
            return publishedRule;
        }

        public async Task<Rule> FromWorkspace(string ruleId)
        {
            if (_workspace == null)
                throw new InvalidOperationException("A Rulebricks client is required to load a rule from the workspace");

            var ruleData = await _workspace.Assets.ExportRuleAsync(new ExportRuleRequest { Id = ruleId });
            return FromJson(JsonSerializer.Serialize(ruleData));
        }

        public Dictionary<string, object> ToDict()
        {
            var dict = new Dictionary<string, object>
            {
                { "id", Id },
                { "name", Name },
                { "description", Description },
                { "slug", Slug },
                { "tag", FolderId },
                { "published", Published },
                { "publishedAt", PublishedAt },
                { "createdAt", CreatedAt },
                { "updatedAt", UpdatedAt },
                { "updatedBy", UpdatedBy },
                { "requestSchema", _requestFields.Select(f => f.Value.ToDict()).ToList() },
                { "responseSchema", _responseFields.Select(f => f.Value.ToDict()).ToList() },
                { "conditions", _conditions },
                { "testSuite", _testSuite.Select(t => t.ToDict()).ToList() },
                { "accessGroups", _accessGroups }
            };

            return dict;
        }

        public string ToJson()
        {
            return JsonSerializer.Serialize(ToDict(), new JsonSerializerOptions
            {
                WriteIndented = true
            });
        }

        public static Rule FromJson(string jsonString)
        {
            var data = JsonSerializer.Deserialize<Dictionary<string, JsonElement>>(jsonString);
            var rule = new Rule();

            if (data.TryGetValue("id", out var id))
                rule.Id = id.GetString();
            if (data.TryGetValue("name", out var name))
                rule.Name = name.GetString();
            if (data.TryGetValue("description", out var description))
                rule.Description = description.GetString();
            if (data.TryGetValue("slug", out var slug))
                rule.Slug = slug.GetString();
            if (data.TryGetValue("tag", out var tag))
                rule.FolderId = tag.GetString();
            if (data.TryGetValue("published", out var published))
                rule.Published = published.GetBoolean();
            if (data.TryGetValue("publishedAt", out var publishedAt))
                rule.PublishedAt = publishedAt.GetString();
            if (data.TryGetValue("createdAt", out var createdAt))
                rule.CreatedAt = createdAt.GetString();
            if (data.TryGetValue("updatedAt", out var updatedAt))
                rule.UpdatedAt = updatedAt.GetString();
            if (data.TryGetValue("updatedBy", out var updatedBy))
                rule.UpdatedBy = updatedBy.GetString();

            if (data.TryGetValue("requestSchema", out var requestSchema))
            {
                foreach (var field in requestSchema.EnumerateArray())
                {
                    var fieldData = JsonSerializer.Deserialize<Dictionary<string, JsonElement>>(field.GetRawText());
                    var fieldType = Enum.Parse<FieldType>(fieldData["type"].GetString(), true);
                    var key = fieldData["key"].GetString();
                    var fieldDescription = fieldData.GetValueOrDefault("description").GetString() ?? "";

                    switch (fieldType)
                    {
                        case FieldType.Boolean:
                            rule.AddBooleanField(key, fieldDescription, fieldData.GetValueOrDefault("defaultValue").GetBoolean());
                            break;
                        case FieldType.Number:
                            rule.AddNumberField(key, fieldDescription, fieldData.GetValueOrDefault("defaultValue").GetDouble());
                            break;
                        case FieldType.String:
                            rule.AddStringField(key, fieldDescription, fieldData.GetValueOrDefault("defaultValue").GetString() ?? "");
                            break;
                        case FieldType.Date:
                            rule.AddDateField(key, fieldDescription);
                            break;
                        case FieldType.List:
                            rule.AddListField(key, fieldDescription);
                            break;
                    }
                }
            }

            if (data.TryGetValue("responseSchema", out var responseSchema))
            {
                foreach (var field in responseSchema.EnumerateArray())
                {
                    var fieldData = JsonSerializer.Deserialize<Dictionary<string, JsonElement>>(field.GetRawText());
                    var fieldType = Enum.Parse<FieldType>(fieldData["type"].GetString(), true);
                    var key = fieldData["key"].GetString();
                    var fieldDescription = fieldData.GetValueOrDefault("description").GetString() ?? "";

                    switch (fieldType)
                    {
                        case FieldType.Boolean:
                            rule.AddBooleanResponse(key, fieldDescription, fieldData.GetValueOrDefault("defaultValue").GetBoolean());
                            break;
                        case FieldType.Number:
                            rule.AddNumberResponse(key, fieldDescription, fieldData.GetValueOrDefault("defaultValue").GetDouble());
                            break;
                        case FieldType.String:
                            rule.AddStringResponse(key, fieldDescription, fieldData.GetValueOrDefault("defaultValue").GetString() ?? "");
                            break;
                        case FieldType.Date:
                            rule.AddDateResponse(key, fieldDescription);
                            break;
                        case FieldType.List:
                            rule.AddListResponse(key, fieldDescription);
                            break;
                    }
                }
            }

            if (data.TryGetValue("conditions", out var conditions))
            {
                rule._conditions.AddRange(conditions.EnumerateArray()
                    .Select(c => JsonSerializer.Deserialize<Dictionary<string, object>>(c.GetRawText())));
            }

            if (data.TryGetValue("testSuite", out var testSuite))
            {
                rule._testSuite.AddRange(testSuite.EnumerateArray()
                    .Select(t => RuleTest.FromJson(t.GetRawText())));
            }

            return rule;
        }

        public RuleTest AddTest()
        {
            var test = new RuleTest();
            _testSuite.Add(test);
            return test;
        }

        public void RemoveTest(string testId)
        {
            _testSuite.RemoveAll(t => t.Id == testId);
        }

        public RuleTest FindTestById(string testId)
        {
            return _testSuite.FirstOrDefault(t => t.Id == testId);
        }

        public RuleTest FindTestByName(string testName)
        {
            return _testSuite.FirstOrDefault(t => t.Name == testName);
        }

        public Condition When(Dictionary<string, (string, object[])> conditions)
        {
            return new Condition(this, conditions);
        }

        public Condition Any(Dictionary<string, (string, object[])> conditions)
        {
            return new Condition(this, conditions, new Dictionary<string, object> { { "or", true } });
        }

        private string GenerateSlug(int length = 10)
        {
            const string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random();
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
