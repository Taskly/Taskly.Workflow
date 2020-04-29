using System.Collections.Generic;

namespace WorkflowService.WebApi.Dto
{
    public abstract class ListBase<T>
    {
        public ListBase(List<T> items)
        {
            Items = items;
        }

        public List<T> Items { get; set; }
    }
}
