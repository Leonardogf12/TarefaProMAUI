using TarefaPro.MAUI.MVVM.Models;

namespace TarefaPro.MAUI.Services.Firebase
{
    public interface INotificationFirebaseService
    {
        Task<bool> PostNotificationAsync(NotificationDto model, string token);
    }
}
