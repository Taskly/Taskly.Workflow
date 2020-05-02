using System;

namespace Taskly.Workflow.Domain
{
    public class WorkItemStatus
    {
        public WorkItemStatus(string title)
        {
            Title = title;
        }

        public static WorkItemStatus Default => new WorkItemStatus("New");

        public string Title { get; }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (obj.GetType() != GetType())
            {
                return false;
            }

            return Equals((WorkItemStatus)obj);
        }

        public bool Equals(WorkItemStatus other)
        {
            return string.Equals(Title, other.Title, StringComparison.OrdinalIgnoreCase);
        }

        public override int GetHashCode()
        {
            return StringComparer.OrdinalIgnoreCase.GetHashCode(Title);
        }

        public static bool operator ==(WorkItemStatus left, WorkItemStatus right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(WorkItemStatus left, WorkItemStatus right)
        {
            return !Equals(left, right);
        }
    }
}
