using System;

namespace SepaWriter.Utils
{
    public static class SepaSchemaUtils
    {
        public static string SepaSchemaToString(SepaSchema schema)
        {
            switch (schema)
            {
                case SepaSchema.Pain00800102:
                    return "pain.008.001.02";
                case SepaSchema.Pain00800103:
                    return "pain.008.001.03";
                case SepaSchema.Pain00800108:
                    return "pain.008.001.08";
                case SepaSchema.Pain00100103:
                    return "pain.001.001.03";
                case SepaSchema.Pain00100104:
                    return "pain.001.001.04";
                case SepaSchema.Pain00100109:
                    return "pain.001.001.09";
                default:
                    throw new ArgumentException("unknown schema " + schema);
            }
        }

        public static bool IsIso20022V2019(SepaSchema schema)
        {
            return schema == SepaSchema.Pain00100109 || schema == SepaSchema.Pain00800108;
        }

        public static string BicElementName(SepaSchema schema)
        {
            return IsIso20022V2019(schema) ? "BICFI" : "BIC";
        }
    }
}
