using System.Collections.Generic;

namespace ActiveOrInactiveStateManagement
{
    public interface ISingleItemActiveStateManager<T> where T : IActiveOrInactiveState
    {
        T GetActive();
    }
}