using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Futronic.MfAPIHelper;

namespace  FASClient

{
    public enum ParameterFields
    {
        pf_none = 0,
        pf_userID = 0x01,
        pf_sampleCount = 0x02,
        pf_Flag = 0x04,
        pf_userPIN = 0x08,
        pf_masterPIN = 0x10,
        pf_LFD = 0x20
    }

    public class OperationParameters
    {
        public ulong UserID;
        public int sampleCount;
        public byte Flag;
        public String userPIN;
        public String masterPIN;
        public ParameterFields bits;
        public bool bLfd;
    }

    public enum Operations
    {
        add_user_finger_only,
        add_cou_wo_finger_wp,
        add_cou_wo_finger,
        add_cou_w1_finger,
        add_csn_w_finger,
        add_csn_w_pin,
        init_reader,
        format_card,
        format_card_short,
        format_card_special,
        erase_card,
        get_card_free_space,
        unformat_card,
        make_mastercard,
        copy_mastercard,
        change_mcard_pin,
        save_cou_to_card,
        save_uid_to_card,
        save_tml_to_card,
        show_csn,
        show_csn_masterCard,
        recognize_user_db,
        recognize_user_card
    }

    public class ThreadParameters
    {
        public DeviceSequence ds;
        public Operations currentOperation;
        public OperationParameters opParameters;
    }
}
