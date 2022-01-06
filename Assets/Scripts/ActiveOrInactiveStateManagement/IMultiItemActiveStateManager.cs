using System.Collections.Generic;

namespace ActiveOrInactiveStateManagement
{
    public interface IMultiItemActiveStateManager<T> : IActiveStateManager<T> where T : IActiveOrInactiveState
    {
        ICollection<T> GetActive();
    }
}