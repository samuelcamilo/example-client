namespace Example.Client.App.Model
{
    public class Distance
    {
        public string Text { get; set; }
        public int Value { get; set; }

        public Distance(string text, int value) 
        {
            this.Text = text;
            this.Value = value;
        }
    }
}