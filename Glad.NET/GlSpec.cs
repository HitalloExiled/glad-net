using System.Xml;
using Glad.Spec;

namespace Glad
{
    public sealed class GlSpec
    {
        private readonly string apiUrl = "https://raw.githubusercontent.com/KhronosGroup/OpenGL-Registry/master/xml/gl.xml";
        private XmlElement root;

        public List<Group> Groups { get; }

        public List<Enumeration> Enums { get; }

        public List<Command> Commands { get; }

        public List<Feature> Features { get; }

        public List<Extension> Extensions { get; }

        public GlSpec()
        {
            Groups = new List<Group>();
            Enums = new List<Enumeration>();
            Commands = new List<Command>();
            Features = new List<Feature>();
            Extensions = new List<Extension>();
        }

        public async Task Load()
        {
            using var client = new HttpClient();
            using var stream = await client.GetStreamAsync(this.apiUrl);

            var doc = new XmlDocument();
            doc.Load(stream);
            root = doc.DocumentElement;

            this.Parse();
        }

        private void Parse()
        {
            // ParseGroups();
            ParseEnums();
            ParseCommands();
            ParseFeatures();
            ParseExtensions();
        }

        private void ParseExtensions()
        {
            Extensions.Clear();
            foreach (XmlElement ext in root["extensions"].GetElementsByTagName("extension"))
            {
                Extensions.Add(new Extension(ext));
            }
        }

        private void ParseFeatures()
        {
            Features.Clear();
            foreach (var feature in root.GetElementsByTagName("feature"))
            {
                if (feature is XmlElement entry)
                    Features.Add(new Feature(entry));
            }
        }

        public async Task ParseAsync() => await new Task(Parse);

        private void ParseGroups()
        {
            Groups.Clear();
            foreach (XmlElement group in root["groups"].GetElementsByTagName("group"))
                Groups.Add(new Group(group));
        }

        private void ParseEnums()
        {
            Enums.Clear();
            foreach (XmlElement node in root.GetElementsByTagName("enums"))
                Enums.Add(new Enumeration(node));
        }

        private void ParseCommands()
        {
            Commands.Clear();
            foreach (XmlElement node in root["commands"].GetElementsByTagName("command"))
                Commands.Add(new Command(node));
        }

        public IEnumerable<Command> GetCommands(Api api, Version version, Profile profile)
        {
            foreach (var name in Fetch(api, version, profile, FeatureType.Command))
                yield return Commands.Find(cmd => cmd.Name.Equals(name, StringComparison.Ordinal));
        }

        public IEnumerable<EnumMember> GetEnums(Api api, Version version, Profile profile)
        {
            var allEnums = Enums.SelectMany(e => e).ToList();
            foreach (var name in Fetch(api, version, profile, FeatureType.Enum))
            {
                foreach (var member in allEnums)
                {
                    if (!member.Name.Equals(name, StringComparison.Ordinal)) continue;
                    yield return member;
                    break;
                }
            }

        }

        private IEnumerable<string> Fetch(Api api, Version version, Profile profile, FeatureType type)
        {
            var set = new HashSet<string>();
            foreach (var feature in Features)
            {
                if (feature.Version > version)
                    continue;
                if (!feature.Api.HasFlag(api))
                    continue;

                foreach (var item in feature)
                {
                    if (!item.Type.HasFlag(type))
                        continue;

                    if (!item.Profile.HasFlag(profile))
                        continue;

                    if (item.Action == FeatureAction.Require)
                        set.Add(item.Name);
                    if (item.Action == FeatureAction.Remove)
                        set.Remove(item.Name);
                }
            }

            return set;
        }
    }
}
