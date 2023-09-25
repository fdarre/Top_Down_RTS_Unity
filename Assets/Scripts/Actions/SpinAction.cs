using UnityEngine;

namespace TurnBased3DRTS.Actions
{
   public class SpinAction : BaseAction
   {
      public delegate void SpinCompleteDelegate();

      private float _totalSpinAmount = 0f;
      private ActionCompleteDelegate _onActionComplete;

      private void Update()
      {
         if (!isActive) return;

         float spinAddAmount = 360f * Time.deltaTime;
         transform.eulerAngles += new Vector3(0f, spinAddAmount, 0f);

         _totalSpinAmount += spinAddAmount;

         if(_totalSpinAmount >= 360f)
         {
            isActive = false;
            _onActionComplete();
         }
      }

      public void Spin(ActionCompleteDelegate onActionComplete = null)
      {
         isActive = true;
         _totalSpinAmount = 0f;
         this._onActionComplete = onActionComplete;
      }
   }
}
