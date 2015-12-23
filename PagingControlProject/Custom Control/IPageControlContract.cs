namespace PagingControlProject.Custom_Control
{
    using System.Collections.Generic;

    public interface IPageControlContract
    {
        int GetTotalCount();
        ICollection<object> GetRecordsBy(int startingIndex, int numberOfRecords, object sortData);
    }
}
