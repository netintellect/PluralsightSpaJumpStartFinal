
namespace Telerik.Windows.Examples.ScheduleView.SchedulingAssistant
{
    public class Employee
    {
        public string Name { get; set; }
        public string ImageSource { get; set; }

        public override int GetHashCode()
        {
            return this.Name.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj is Employee)
            {
                return this.Name == (obj as Employee).Name;
            }

            return base.Equals(obj);
        }
    }
}
