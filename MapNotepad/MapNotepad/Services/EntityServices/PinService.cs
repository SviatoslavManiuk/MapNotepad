using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MapNotepad.Helpers.ProcessHelpers;
using MapNotepad.Model;
using MapNotepad.Services.Repository;

namespace MapNotepad.Services.EntityServices
{
    public class PinService
    {
        private IRepositoryService _repositoryService;

        public PinService(IRepositoryService repositoryService)
        {
            _repositoryService = repositoryService;
        }

        public async Task<AOResult<int>> InsertAsync(PinModel pin)
        {
            var result = new AOResult<int>();
            
            try
            {
                int numRowsInserted =  await _repositoryService.InsertAsync(pin);
                if (numRowsInserted != 0)
                {
                    result.SetSuccess(numRowsInserted);
                }
                else
                {
                    result.SetFailure();
                }
            }
            catch (Exception e)
            {
                result.SetError($"Exception in: {nameof(InsertAsync)}", "Something went wrong", e);
            }

            return result;
        }

        public async Task<AOResult<int>> DeleteAsync(PinModel pin)
        {
            var result = new AOResult<int>();
            
            try
            {
                int numRowsDeleted =  await _repositoryService.DeleteAsync(pin);
                if (numRowsDeleted != 0)
                {
                    result.SetSuccess(numRowsDeleted);
                }
                else
                {
                    result.SetFailure();
                }
            }
            catch (Exception e)
            {
                result.SetError($"Exception in: {nameof(DeleteAsync)}", "Something went wrong", e);
            }

            return result;
        }

        public async Task<AOResult<int>> UpdateAsync(PinModel pin)
        {
            var result = new AOResult<int>();
            
            try
            {
                int numRowsUpdated =  await _repositoryService.UpdateAsync(pin);
                if (numRowsUpdated != 0)
                {
                    result.SetSuccess(numRowsUpdated);
                }
                else
                {
                    result.SetFailure();
                }
            }
            catch (Exception e)
            {
                result.SetError($"Exception in: {nameof(UpdateAsync)}", "Something went wrong", e);
            }

            return result;
        }

        public async Task<AOResult<IEnumerable<PinModel>>> GetPinsByUserAsync(int userId)
        {
            var result = new AOResult<IEnumerable<PinModel>>();
            
            try
            {
                var pins =  await _repositoryService.GetTable<PinModel>().Where(pin => pin.UserId == userId).ToListAsync();
                if (pins.Count != 0)
                {
                    result.SetSuccess(pins);
                }
                else
                {
                    result.SetFailure();
                }
            }
            catch (Exception e)
            {
                result.SetError($"Exception in: {nameof(InsertAsync)}", "Something went wrong", e);
            }

            return result;
        }
        
        public async Task<AOResult<PinModel>> FindByCoordinatesAsync(double longitude, double latitude)
        {
            var result = new AOResult<PinModel>();
            
            try
            {
                var pin = await _repositoryService.FindWithQueryAsync<PinModel>("SELECT * FROM Pin WHERE Longitude = ? And Latidude = ?", longitude, latitude);
                if (pin != null)
                {
                    result.SetSuccess(pin);
                }
                else
                {
                    result.SetFailure();
                }
            }
            catch (Exception ex)
            {
                result.SetError($"{nameof(FindByCoordinatesAsync)} exception: ", "Something went wrong", ex);
            }

            return result;
        }
        
    }
}