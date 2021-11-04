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
        private IRepository _repository;

        public PinService(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<AOResult<int>> InsertAsync(PinModel pin)
        {
            var result = new AOResult<int>();
            
            try
            {
                int numRowsInserted =  await _repository.InsertAsync(pin);
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
                int numRowsDeleted =  await _repository.DeleteAsync(pin);
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
                int numRowsUpdated =  await _repository.UpdateAsync(pin);
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

        public async Task<AOResult<List<PinModel>>> GetPinsByUserAsync(int userId)
        {
            var result = new AOResult<List<PinModel>>();
            
            try
            {
                var pins =  await _repository.GetTable<PinModel>().Where(pin => pin.UserId == userId).ToListAsync();
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
    }
}