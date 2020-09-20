using Accord.Math;
using Microsoft.ML.OnnxRuntime;
using Microsoft.ML.OnnxRuntime.Tensors;
using System;
using System.Collections.Generic;

namespace AIServer.AI
{
    public class AiSingleNumber
    {
        public AiSingleNumber()
        {
            Session = new InferenceSession("C:/Users/User/Documents/Нейронки/PythonAINumber/model.onnx");
        }

        InferenceSession Session { get; }

        public int DefineNumber(float[] inputData)
        {
            int outItemNumber = -1;
            var inputMeta = Session.InputMetadata;
            var inputs = new List<NamedOnnxValue>();

            int count = 0;

            foreach (var name in inputMeta.Keys)
            {
                var tensor = new DenseTensor<float>(inputData, new int[] { 1, 28, 28 });
                inputs.Add(NamedOnnxValue.CreateFromTensor<float>(name, tensor));
                count++;
            }

            using (var outputs1 = Session.Run(inputs))
            {
                foreach (var n in outputs1)
                {
                    float[] outs = (n.Value as DenseTensor<float>).Buffer.ToArray();
                    float number = 0;
                    foreach (var nn in outs)
                    {
                        if (nn > number)
                            number = nn;
                    }

                    outItemNumber = outs.IndexOf(number);
                    if (outItemNumber >= 0)
                        return outItemNumber;
                }

            }
            return outItemNumber;
        }
    }
}
