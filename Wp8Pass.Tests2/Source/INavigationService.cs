using System;

namespace Caliburn.Micro
{
    /// <summary>
    ///   Implemented by services that provide (<see cref="Uri" /> based) navigation.
    /// </summary>
    public interface INavigationService
    {
        /// <summary>
        ///   Indicates whether the navigator can navigate back.
        /// </summary>
        bool CanGoBack { get; }

        /// <summary>
        ///   Navigates back.
        /// </summary>
        void GoBack();
    }
}