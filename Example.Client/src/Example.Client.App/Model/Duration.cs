namespace Example.Client.App.Model
{
    public class Duration
    {
        public string Text { get; set; }
        public int Value { get; set; }

        public Duration(string text, int value) 
        {
            this.Text = text;
            this.Value = value;
        }
    }
}