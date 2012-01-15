/*
 * COPYRIGHT(c)2009 Afrel Co., Ltd.
 * ActionController.c
 * 行動制御クラス(収集側)
 *
 * クラス名: ActionController(C)
 * 属性: currentStatus,   REQUESTWAIT, COLLECTIONMOVE, CARRYWAIT, CARRYPRESS, REVERSAL,RETURN, CRUMBLE,		
 *       LIFTWAIT, LIFTPRESS, TAKEOVER, GARAGE, FINISH			
 * 操作: pre, post
 * 関連: LineDriveController(LDC), LuggageCarrierUnit(LCU), BumperUnit(BU), DisplayUnit(DU),
 *       HornUnit(HU), TimerUnit(TU), CommUnit(CU), itron, kernel_id
 */

#include "ActionController.h"
#include "kernel.h"
#include "kernel_id.h"

// TODO 下のコードがパースできるか検証する
//void DeclareCounter(SysTimerCnt); // add void return type
static int i,j; // replace from S8 to int


/*
 * ActionController Status
 */
enum AC_Status {
  AC_REQUESTWAIT,	/**< status 0 収集依頼待機*/
  AC_COLLECTIONMOVE,/**< status 1 収集移動中*/
  AC_CARRYWAIT,		/**< status 2 荷物積載待機*/
  AC_CARRYPRESS,	/**< status 3 荷物積載催促*/
  AC_REVERSAL,		/**< status 4 反転する*/
  AC_RETURN,		/**< status 5 帰還する*/
  AC_CRUMBLE,		/**< status 6 荷崩れ中*/
  AC_LIFTWAIT,		/**< status 7 荷降ろし待機*/
  AC_LIFTPRESS,		/**< status 8 荷降ろし催促中*/
  AC_FINISH			/**< status 9 終了*/
};



/** 現在の状態 */
static int AC_currentStatus = AC_REQUESTWAIT;
//static int AC_currentStatus = AC_FINISH;

static int reverse_state = 0;

/* private関数 */
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

//後始末処理
void ecrobot_device_terminate(){    
	ecrobot_init_bt_slave("LEJOS-OSEK");
	WDC_post();
}

static void AC_log(){
	ecrobot_bt_data_logger(AC_currentStatus, j--);
	ecrobot_status_monitor("Data Logging");
	}

/**
 * 行動制御の初期化処理
 * モータとかの初期化か？
 */
void AC_pre(void) {
	// HU_okSound(); // テスト用

	/** 移動制御 */
	LDC_pre();

	/** メール送受信関係 */	
	//CU_set_sendMSG(77);		/** 送信メッセージの設定 */
	//CU_set_recvMSG(77);		/** 受信メッセージの設定 */

	/** Bluetoothデバイスアドレス（スレーブ） */
	//static UB bd_addr[7] = {0x00, 0x16, 0x53, 0x09, 0x57, 0x9a, 0x00};
	//CU_set_mode(1, bd_addr);	/** マスタに設定 */
	//CU_pre();

	WDC_pre();
	//ecrobot_init_sonar_sensor(NXT_PORT_S4);
}

/**
 * 行動制御の終了処理

 */
void AC_post(void) {





}

/**
 * 収集依頼待機
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
 * 収集移動中
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
 * 荷物積載待機
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
 * 荷物積載催促中
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
 * 反転中
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
 * 帰還中
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
 * 荷崩れ中
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
 * 荷物降ろし待機
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
 * 荷物降ろし催促中
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
 * 引き継ぎ中
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
 * ステータスの変更を行う
 */
static void AC_changeStatus(int status) {

	if (TU_isStart()) {
		/* タイマ監視中の場合は監視を終了する */
		TU_finish();
	}

	/* ステータスを変更 */
	AC_currentStatus = status;
}

/**
 * 行動制御を行うタスク（優先度：低）
 */
void tsk0(int exinf){ // replace from VP_INT to int

	/* 現在のステータスを表示 */
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

	/** タスクを終了する */
	ext_tsk();
}

//周期ハンドラ0用の関数
void cyc0(int exinf) { // replace from VP_INT to int

	//タスクを起動する
	//具体的には，対象タスクを休止状態から，実行状態に移行させ，
	//タスクの起動時に行うべき処理を行う
	iact_tsk(TSK0);
}

void cyc2(int exinf) { // replace from VP_INT to int
	AC_log();

	
}
