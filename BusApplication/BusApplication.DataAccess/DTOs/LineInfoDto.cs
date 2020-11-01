using System;
using System.Collections.Generic;
using System.Text;

namespace BusApplication.DataAccess.DTOs
{
    public class LineInfoDto
    {
        public LineInfoDto(int id, string name, bool isActive, IList<BusStopDto> busStopDto)
        {
            Id = id;
            Name = name;
            IsActive = isActive;
            this.busStopDto = busStopDto;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public IList<BusStopDto> busStopDto { get; set; }
    }
}
