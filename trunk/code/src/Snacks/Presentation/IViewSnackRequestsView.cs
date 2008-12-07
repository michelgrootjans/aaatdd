using System;
using System.Collections.Generic;
using Snacks.Dto;
using Utilities.Presentation;

namespace Snacks.Presentation
{
    public interface IViewSnackRequestsView : IView
    {
        event EventHandler GetAllSnackRequests;
        IEnumerable<SnackRequestDto> SnackRequests { set; }
    }
}