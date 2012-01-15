/*
 * COPYRIGHT(c)2009 Afrel Co., Ltd.
 * ActionController.c
 * �s������N���X(���W��)
 *
 * �N���X��: ActionController(C)
 * ����: currentStatus,   REQUESTWAIT, COLLECTIONMOVE, CARRYWAIT, CARRYPRESS, REVERSAL,RETURN, CRUMBLE,		
 *       LIFTWAIT, LIFTPRESS, TAKEOVER, GARAGE, FINISH			
 * ����: pre, post
 * �֘A: LineDriveController(LDC), LuggageCarrierUnit(LCU), BumperUnit(BU), DisplayUnit(DU),
 *       HornUnit(HU), TimerUnit(TU), CommUnit(CU), itron, kernel_id
 */

#include "ActionController.h"
#include "kernel.h"
#include "kernel_id.h"

// TODO ���̃R�[�h���p�[�X�ł��邩���؂���
//void DeclareCounter(SysTimerCnt); // add void return type
static int i,j; // replace from S8 to int


/*
 * ActionController Status
 */
enum AC_Status {
  AC_REQUESTWAIT,	/**< status 0 ���W�˗��ҋ@*/
  AC_COLLECTIONMOVE,/**< status 1 ���W�ړ���*/
  AC_CARRYWAIT,		/**< status 2 �ו��ύڑҋ@*/
  AC_CARRYPRESS,	/**< status 3 �ו��ύڍÑ�*/
  AC_REVERSAL,		/**< status 4 ���]����*/
  AC_RETURN,		/**< status 5 �A�҂���*/
  AC_CRUMBLE,		/**< status 6 �ו��ꒆ*/
  AC_LIFTWAIT,		/**< status 7 �׍~�낵�ҋ@*/
  AC_LIFTPRESS,		/**< status 8 �׍~�낵�Ñ���*/
  AC_FINISH			/**< status 9 �I��*/
};



/** ���݂̏�� */
static int AC_currentStatus = AC_REQUESTWAIT;
//static int AC_currentStatus = AC_FINISH;

static int reverse_state = 0;

/* private�֐� */
static void AC_request_wait(void);
static void AC_collection_move(void);
static void AC_carry_wait(void);
static void AC_carry_press(void);
static void AC_reversal(int state);
static void AC_return(void);
static void AC_crumble(void);
static void AC_lift_wait(void);
static void AC_lift_press(void);
//static void AC_takeover(void);
static void AC_finish(void);


static void AC_changeStatus(int status);

void ecrobot_device_initialize(void) {
	ecrobot_init_bt_slave("LEJOS-OSEK");
	AC_pre();
}

//��n������
void ecrobot_device_terminate(){    
	ecrobot_init_bt_slave("LEJOS-OSEK");
	WDC_post();
}

static void AC_log(){
	ecrobot_bt_data_logger(AC_currentStatus, j--);
	ecrobot_status_monitor("Data Logging");
	}

/**
 * �s������̏���������
 * ���[�^�Ƃ��̏��������H
 */
void AC_pre(void) {
	// HU_okSound(); // �e�X�g�p

	/** �ړ����� */
	LDC_pre();

	/** ���[������M�֌W */	
	//CU_set_sendMSG(77);		/** ���M���b�Z�[�W�̐ݒ� */
	//CU_set_recvMSG(77);		/** ��M���b�Z�[�W�̐ݒ� */

	/** Bluetooth�f�o�C�X�A�h���X�i�X���[�u�j */
	//static UB bd_addr[7] = {0x00, 0x16, 0x53, 0x09, 0x57, 0x9a, 0x00};
	//CU_set_mode(1, bd_addr);	/** �}�X�^�ɐݒ� */
	//CU_pre();

	WDC_pre();
	//ecrobot_init_sonar_sensor(NXT_PORT_S4);
}

/**
 * �s������̏I������

 */
void AC_post(void) {





}

/**
 * ���W�˗��ҋ@
 */
static void AC_request_wait(void) {
	DU_showString("1stPhase");
	while(!BU_isTouched()){
		LDC_stop();

	}
	if(!TU_isStart()){
		TU_start(100);
	}
	if(TU_isTimeout()){
		HU_confirSound();
		TU_finish();

		AC_changeStatus(AC_COLLECTIONMOVE);
	}

}

/**
 * ���W�ړ���
 */
static void AC_collection_move(void) {
	DU_showString("2ndPhase");
	LDC_pre();
	while(!BU_isTouched()){
		LDC_linetrace();
	}
	
	if(!TU_isStart()){
		TU_start(100);
	}
	if(TU_isTimeout()){
		HU_confirSound();
		TU_finish();
		AC_changeStatus(AC_CARRYWAIT);
	}
}

/**
 * �ו��ύڑҋ@
 */
static void AC_carry_wait(void) {
	DU_showString("3rdPhase");
	
	if(!TU_isStart()){
		TU_start(3000);
	}
	while(!ecrobot_get_touch_sensor(NXT_PORT_S2)){
		LDC_stop();
		if(TU_isTimeout()){
		HU_confirSound();
		TU_finish();
		AC_changeStatus(AC_CARRYPRESS);
		return;
		}
	}
	reverse_state =0;
	AC_changeStatus(AC_REVERSAL);




}

/**
 * �ו��ύڍÑ���
 */
static void AC_carry_press(void) {
	DU_showString("4thPhase");
	while(!ecrobot_get_touch_sensor(NXT_PORT_S2)){
	LDC_stop();
	HU_confirSound();
	}
	AC_changeStatus(AC_REVERSAL);


}

/**
 * ���]��
 */
static void AC_reversal(int state) {

	DU_showString("5thPhase");
	
	 MU_backward();
	systick_wait_ms(1500);
	 
	
	 
	 LDC_pre();
	
	 LDC_quickLeft();
	 systick_wait_ms(2500);
	 
	
	 while(!LMU_isOnline()){
		LDC_reverseLeft();
	}
	
	
	
	
	
	AC_changeStatus(AC_RETURN);
		
	

}

/**
 * �A�Ғ�
 */
static void AC_return(void) {
	
	DU_showString("Return!!");
	
	LDC_pre();
	
	
	while(!BU_isTouched()){
		LDC_linetrace2();
		if(!ecrobot_get_touch_sensor(NXT_PORT_S2)){
			AC_changeStatus(AC_CRUMBLE);
			return;
		}
	}
	
	if(!TU_isStart()){
		TU_start(100);
	}
	if(TU_isTimeout()){
		HU_confirSound();
		TU_finish();
		AC_changeStatus(AC_LIFTWAIT);
	}
}


/**
 * �ו��ꒆ
 */
static void AC_crumble(void) {

DU_showString("crumble");
	while(!ecrobot_get_touch_sensor(NXT_PORT_S2)){
	LDC_stop();
	HU_confirSound();
	}
	AC_changeStatus(AC_RETURN);



}

/**
 * �ו��~�낵�ҋ@
 */
static void AC_lift_wait(void) {

DU_showString("LIFT WAIT");
	
	if(!TU_isStart()){
		TU_start(3000);
	}
	while(ecrobot_get_touch_sensor(NXT_PORT_S2)){
		LDC_stop();
		if(TU_isTimeout()){
		HU_confirSound();
		TU_finish();
		AC_changeStatus(AC_LIFTPRESS);
		return;
		}
	}
	
	AC_changeStatus(AC_FINISH);
	


}

/**
 * �ו��~�낵�Ñ���
 */
static void AC_lift_press(void) {

	DU_showString("Hurry lift off");
	while(ecrobot_get_touch_sensor(NXT_PORT_S2)){
		LDC_stop();
		HU_confirSound();
	}
	AC_changeStatus(AC_FINISH);



}

/**
 * �����p����
 */


static void AC_finish(void){
	//DU_showString(ecrobot_get_sonar_sensor(NXT_PORT_S4));
	//WDC_pre();
	//while(!BU_isTouched()){
		//WDC_walltrace();
//		if(ecrobot_get_sonar_sensor(NXT_PORT_S4)<=15){
//			MU_stop();
//		}else{
//			MU_forward();
//		}
	
		//while(BU_isTouched()) MU_stop();;
		DU_showString("finish");

}

/**
 * �X�e�[�^�X�̕ύX���s��
 */
static void AC_changeStatus(int status) {

	if (TU_isStart()) {
		/* �^�C�}�Ď����̏ꍇ�͊Ď����I������ */
		TU_finish();
	}

	/* �X�e�[�^�X��ύX */
	AC_currentStatus = status;
}

/**
 * �s��������s���^�X�N�i�D��x�F��j
 */
void tsk0(int exinf){ // replace from VP_INT to int

	/* ���݂̃X�e�[�^�X��\�� */
	DU_showNumber(AC_currentStatus);

	switch (AC_currentStatus) {
		case AC_REQUESTWAIT:
			AC_request_wait();
			break;
		case AC_COLLECTIONMOVE:
			AC_collection_move();
			break;
		case AC_CARRYWAIT:
			AC_carry_wait();
			break;
		case AC_CARRYPRESS:
			AC_carry_press();
			break;
		case AC_REVERSAL:
			AC_reversal(AC_RETURN);
			break;
		case AC_RETURN:
			AC_return();
			break;
		case AC_CRUMBLE:
			AC_crumble();
			break;
		case AC_LIFTWAIT:
			AC_lift_wait();
			break;
		case AC_LIFTPRESS:
			AC_lift_press();
			break;
		case AC_FINISH:
			AC_finish();
			break;
	}

	/** �^�X�N���I������ */
	ext_tsk();
}

//�����n���h��0�p�̊֐�
void cyc0(int exinf) { // replace from VP_INT to int

	//�^�X�N���N������
	//��̓I�ɂ́C�Ώۃ^�X�N���x�~��Ԃ���C���s��ԂɈڍs�����C
	//�^�X�N�̋N�����ɍs���ׂ��������s��
	iact_tsk(TSK0);
}

void cyc2(int exinf) { // replace from VP_INT to int
	AC_log();

	
}
