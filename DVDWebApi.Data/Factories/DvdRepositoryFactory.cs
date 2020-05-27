using DVDWebApi.Data.ADO;
using DVDWebApi.Data.DataInterfaces;
using DVDWebApi.Data.DataMockup;
using System;

namespace DVDWebApi.Data.DataFactories
{
    public static class DvdRepositoryFactory
    {
        public static IDvdRepository GetRepository()
        {
            switch (Settings.GetRepositoryType())
            {
                case "Mockup":
                    return new DvdRepositoryMock();
                case "ADO":
                    return new DvdRepositoryADO();
                default:
                    throw new Exception("Could not find the configured repository.");
            }
        }
    }
}
