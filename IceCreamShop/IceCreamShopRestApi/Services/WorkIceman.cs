using IceCreamShopServiceDAL.BindingModels;
using IceCreamShopServiceDAL.Interfaces;
using System;
using System.Threading;

namespace IceCreamShopRestApi.Services
{
    public class WorkIceman
    {
        private readonly IMainService _service;

        private readonly IIcemanService _serviceIceman;

        private readonly int _implementerId;

        private readonly int _orderId;

        // семафор
        static Semaphore _sem = new Semaphore(3, 3);

        Thread myThread;

        public WorkIceman(IMainService service, IIcemanService serviceIceman, int implementerId, int orderId)
        {
            _service = service;
            _serviceIceman = serviceIceman;
            _implementerId = implementerId;
            _orderId = orderId;
            try
            {
                _service.TakeBookingInWork(new BookingBindingModel
                {
                    Id = _orderId,
                    IcemanId = _implementerId
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            myThread = new Thread(Work);
            myThread.Start();
        }
        public void Work()
        {
            try
            {
                // забиваем мастерскую
                _sem.WaitOne();
                // Типа выполняем
                Thread.Sleep(10000);
                _service.FinishBooking(new BookingBindingModel
                {
                    Id = _orderId
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                // освобождаем мастерскую
                _sem.Release();
            }
        }
    }
}