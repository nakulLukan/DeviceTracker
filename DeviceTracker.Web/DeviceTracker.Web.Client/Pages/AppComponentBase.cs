﻿using Microsoft.AspNetCore.Components;

namespace DeviceTracker.Web.Client.Pages;
public class AppComponentBase : ComponentBase
{
    [Parameter]
    public bool IsInitialized { get; set; }
    protected bool _isLoading;

    protected void ChangeToLoadingState(ref bool isLoading)
    {
        isLoading = true;
        StateHasChanged();
    }

    protected void ChangeToLoadingState()
    {
        _isLoading = true;
        StateHasChanged();
    }

    protected void ChangeToLoadedState(ref bool isLoading)
    {
        isLoading = false;
        InvokeAsync(StateHasChanged);
    }

    protected void ChangeToLoadedState()
    {
        _isLoading = false;
        InvokeAsync(StateHasChanged);
    }

    protected void Refresh()
    {
        InvokeAsync(StateHasChanged);
    }

    protected static int GetNumberOfPages(int totalRecords, int pageSize)
    {
        return (int)Math.Ceiling(totalRecords / (double)pageSize);
    }

    protected static int GetPageSkipValue(int selectedPage, int pageSize)
    {
        return (selectedPage - 1) * pageSize;
    }

    protected void SetInitialized()
    {
        IsInitialized = true;
        StateHasChanged();
    }
}