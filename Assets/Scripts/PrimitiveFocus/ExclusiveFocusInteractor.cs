using System;
using ActiveOrInactiveStateManagement;
using UnityEngine.Assertions;

namespace PrimitiveFocus
{
    /// <summary>
    ///     Integrates with the <c>ExclusiveSubSectionFocusManager</c>
    ///     class in order to create an exclusive focus state.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ExclusiveFocusInteractor : FocusInteractor, IExclusiveFocusInteractor
    {
        private ExclusiveSubsectionFocusManager manager;


        public virtual void SetManager(ExclusiveSubsectionFocusManager instanceManager)
        {
            Assert.IsNotNull(instanceManager, $"{nameof(instanceManager)} != null");
            if (instanceManager == null) throw new NullReferenceException("You cannot have a null manager!");
            manager = instanceManager;
        }

        /// <summary>
        ///     The most general form of getting the manager.
        /// </summary>
        /// <returns></returns>
        public override IActiveStateManager<IFocusInteractor> GetManager()
        {
            return manager;
        }


        /// <summary>
        ///     The more specific form if you have access to an instance of this class.
        /// </summary>
        /// <returns></returns>
        public ExclusiveSubsectionFocusManager GetFocusManager()
        {
            return manager;
        }


        public override void OnActivate()
        {
            // just do nothing by default.
        }

        public override void OnInactivate()
        {
            // just do nothing by default.
        }
    }
}