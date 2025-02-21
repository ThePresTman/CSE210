namespace Learning04{

    public class Assignment
    {
        private string _studentName;
        private string _topic;

        public Assignment(string studentName, string topic)
        {
            _studentName = studentName;
            _topic = topic;
        }

        public string GetSummary()
        {
            return $"{_studentName} - {_topic}";
        }

        public string GetStudentName() // Getter to access _studentName in derived classes
        {
            return _studentName;
        }
    }
}