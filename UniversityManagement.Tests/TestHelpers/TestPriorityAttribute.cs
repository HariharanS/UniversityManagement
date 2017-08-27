using System;

namespace UniversityManagement.Tests.TestHelpers
{
    public class TestPriorityAttribute : Attribute
    {
        public int Priority { get; set; }

        public TestPriorityAttribute(int priority)
        {
            Priority = priority;
        }
    }
}