using System.Collections.Generic;

namespace PrimitiveFocus
{
    public interface IUnderlyingIFocusable
    {
        public IFocusable GetIFocusable();
    }
}