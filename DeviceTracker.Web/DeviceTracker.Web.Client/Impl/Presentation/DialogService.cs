using DeviceTracker.Web.Client.Contracts.Presentation;
using DeviceTracker.Web.Client.Pages.Devices.NewDevice;
using MudBlazor;

namespace DeviceTracker.Web.Client.Impl.Presentation;

public class DialogService : IAppDialogService
{
    private readonly IDialogService _dialogService;

    public DialogService(IDialogService dialogService)
    {
        _dialogService = dialogService;
    }
    public async Task<bool> RegisterDeviceDialog()
    {
        var options = new DialogOptions()
        {
            BackdropClick = true,
            NoHeader = true,
            Position = DialogPosition.Center,
            CloseButton = true,
        };
        var dialog = await _dialogService.ShowAsync<NewDeviceDialog>("asd", options);
        var res = (await dialog.Result);
        return res!.Data is bool action && action;
    }

}
