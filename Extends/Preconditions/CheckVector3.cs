using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace BT.Ex {

	public class CheckVector3 : BTPreconditionUseDB {

		private Function _function;
		private List<Vector3> _targets;

        private const float EPSILON = 0.0001f;


		public CheckVector3 (string dataToCheck, Function function, List<Vector3> targets = null) : base (dataToCheck) {
			_function = function;
			_targets = targets;
		}

		public override bool Check () {
			Vector3 data = database.GetData<Vector3>(_dataIdToCheck);
            switch (_function)
            {
                case Function.NotZero:
                    return data != Vector3.zero;
                case Function.Zero:
                    return data == Vector3.zero;
                case Function.XNotZero:
                    return System.Math.Abs(data.x) > EPSILON;
                case Function.XZero:
                    return System.Math.Abs(data.x) < EPSILON;
                case Function.XPositive:
                    return data.x > 0;
                case Function.XNegative:
                    return data.x < 0;
                case Function.XNotPositive:
                    return data.x <= 0;
                case Function.XNotNegative:
                    return data.x >= 0;
                case Function.YNotZero:
                    return System.Math.Abs(data.y) > EPSILON;
                case Function.YZero:
                    return System.Math.Abs(data.y) < EPSILON;
                case Function.YPositive:
                    return data.y > 0;
                case Function.YNegative:
                    return data.y < 0;
                case Function.YNotPositive:
                    return data.y <= 0;
                case Function.YNotNegative:
                    return data.y >= 0;
                case Function.ZNotZero:
                    return System.Math.Abs(data.z) > EPSILON;
                case Function.ZZero:
                    return System.Math.Abs(data.z) < EPSILON;
                case Function.ZPositive:
                    return data.z > 0;
                case Function.ZNegative:
                    return data.z < 0;
                case Function.ZNotPositive:
                    return data.z <= 0;
                case Function.ZNotNegative:
                    return data.z >= 0;
                case Function.MatchAny:
                    foreach (Vector3 target in _targets)
                    {
                        if (data == target)
                        {
                            return true;
                        }
                    }
                    return false;
                case Function.MatchNone:
                    foreach (Vector3 target in _targets)
                    {
                        if (data == target)
                        {
                            return false;
                        }
                    }
                    return true;
            }

            return false;
		}

		public enum Function {
			NotZero,
			Zero,

			XNotZero,
			XZero,
			XPositive,
			XNegative,
			XNotPositive,
			XNotNegative,

			YNotZero,
			YZero,
			YPositive,
			YNegative,
			YNotPositive,
			YNotNegative,

			ZNotZero,
			ZZero,
			ZPositive,
			ZNegative,
			ZNotPositive,
			ZNotNegative,

			MatchAny,
			MatchNone
		}
	}

}