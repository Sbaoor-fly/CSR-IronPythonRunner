using Newtonsoft.Json.Linq;
using CSR;

namespace GUI
{
    public class GUIBuilder
    {
        private MCCSAPI api { get; set; }
        private JObject gui { get; set; }
        private JArray content { get; set; }
        public GUIBuilder(MCCSAPI mcapi, string title) 
        {
            this.api = mcapi;
            this.gui = new JObject();
            BuildNewGUI(title);
        }
        private void BuildNewGUI(string title)
        {
            this.gui = new JObject();
            gui.Add(new JProperty("type", "custom_form"));
            gui.Add(new JProperty(nameof(title), title));
            content = new JArray();
        }
        public void AddLabel(string text) 
        {
            content.Add(new JObject
            {
                new JProperty("type", "label"),
                new JProperty(nameof(text), text)
            });
        }
        public void AddInput(string text,string placeholder = "")
        {
            content.Add(new JObject
            {
                new JProperty("type", "input"),
                new JProperty(nameof(placeholder), placeholder),
                new JProperty("default",""),
                new JProperty("text",text)
            }) ;
        }
        public void AddToggle(string text, bool _default = false) 
        {
            content.Add(new JObject
            {
                new JProperty("type", "toggle"),
                new JProperty("default",_default),
                new JProperty(nameof(text), text)
            });
        }
        public void AddSlider(string text, int min = 0, int max = 100, int step = 1, int _default = 0)
        {
            content.Add(new JObject
            {
                new JProperty("type", "slider"),
                new JProperty("default",_default),
                new JProperty(nameof(text), text),
                new JProperty(nameof(min),min),
                new JProperty(nameof(max),max),
                new JProperty(nameof(step),step)
            });
        }
        public void AddStepSlider(string text, int _default, params string[] options) 
        {
            var t = new JArray();
            foreach (var i in options) t.Add(i);
            content.Add(new JObject
            {
                new JProperty("type", "step_slider"),
                new JProperty("default",_default),
                new JProperty(nameof(text), text),
                new JProperty("steps",t)
            });
        }
        public void AddDropdown(string text, int _default, params string[] options)
        {
            var t = new JArray();
            foreach (var i in options) t.Add(i);
            content.Add(new JObject
            {
                new JProperty("type", "dropdown"),
                new JProperty("default",_default),
                new JProperty(nameof(text), text),
                new JProperty(nameof(options),t)
            }) ;
        }
        public uint SendToPlayer(string uuid)
        {
            gui.Add(new JProperty(nameof(content), content));
            return api.sendCustomForm(uuid, gui.ToString());
        }
    }
}
