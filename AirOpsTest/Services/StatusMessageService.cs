using System.Collections.Generic;
using System.Threading.Tasks;
using AirOpsTest.DtoS;
using AirOpsTest.Entities;
using AirOpsTest.Interfaces;
using AutoMapper;

namespace AirOpsTest.Services
{
    public class StatusMessageService: IStatusMessageService
    {
        private readonly IReadRepository<StatusMessageEntity> _readMessageRepository;
        private readonly IWriteRepository<StatusMessageEntity> _writeMessageRepository;
        private readonly IMapper _mapper;

        public StatusMessageService(IReadRepository<StatusMessageEntity> readMessageRepository,
            IWriteRepository<StatusMessageEntity> writeMessageRepository,
            IMapper mapper)
        {
            _readMessageRepository = readMessageRepository;
            _writeMessageRepository = writeMessageRepository;
            _mapper = mapper;
        }

        public async Task<IList<string>> GetAll()
        {
            return await _readMessageRepository.GetAll();
        }

        public void AddMessage(StatusMessageModel model)
        {
            _writeMessageRepository.Insert(_mapper.Map<StatusMessageEntity>(model));
        }
    }
}