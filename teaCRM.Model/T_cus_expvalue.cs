//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations;

namespace teaCRM.Model
{
    public partial class T_cus_expvalue
    {
        #region Primitive Properties
    	[Required]
    	public virtual int cus_id
        {
            get;
            set;
        }
    	[Required]
        [MaxLength(20)]
    	public virtual string is_marry
        {
            get;
            set;
        }
    	[Required]
        [MaxLength(255)]
    	public virtual string exp_evaluate
        {
            get;
            set;
        }
    	//[Required]
        [MaxLength(20)]
    	public virtual string exp_nation
        {
            get;
            set;
        }
    	[Required]
        [MaxLength(100)]
    	public virtual string exp_email
        {
            get;
            set;
        }
    	//[Required]
    	public virtual Nullable<int> exp_age
        {
            get;
            set;
        }
    	//[Required]
        [MaxLength(50)]
    	public virtual string exp_url
        {
            get;
            set;
        }
    	//[Required]
        [MaxLength(20)]
    	public virtual string exp_nimabi
        {
            get;
            set;
        }
    	//[Required]
        [MaxLength(10)]
    	public virtual string exp_sex
        {
            get;
            set;
        }
    	//[Required]
        [MaxLength(100)]
    	public virtual string exp_attach
        {
            get;
            set;
        }
    	//[Required]
    	public virtual Nullable<System.DateTime> exp_addtime
        {
            get;
            set;
        }

        #endregion
    }
}