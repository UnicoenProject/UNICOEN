/*
 * COPYRIGHT(c)2009 Afrel Co., Ltd.
 * LineDriveController.c
 * ライントレース制御クラス
 *
 * クラス名: LineDriveController(LDC)
 * 属性: なし
 * 操作: pre, post, linetrace, finish, reverse, rightsidetrace, leftsidetrace
 *       leftturn, rightturn, backward
 * 関連: LineMonitorUnit(LMU), MotorUnit(MU), SideMonitorUnit(SMU), common
 */

#include "LineDriveController.h"

#define LEFT_MORTER NXT_PORT_A
#define RIGHT_MORTER NXT_PORT_C
#define LIGHT_SENSOR NXT_PORT_S3
#define SPEED 80
#define LIGHT_THRESHOLD 60

/**
 * ライントレース制御の初期化処理
 */
void LDC_pre(void) {
	//ecrobot_set_light_sensor_active(LIGHT_SENSOR);
	LMU_pre();
	LMU_set_threshold(500);
	MU_set_forwardSpeed(SPEED);
	MU_set_backwardSpeed(30);
}

/**
 * ライントレース制御の終了処理
 */
void LDC_post(void) {
	LDC_stop();
}

/**
 * ライントレースをする
 */
void LDC_linetrace(void) {
	if(LMU_isOnline()){
		MU_forward();
	}
	else{
		LDC_reverseRight();
	}
}
void LDC_linetrace2(void) {
		MU_set_forwardSpeed(SPEED);
	if(LMU_isOnline()){
		MU_forward();
	}
	else{
		LDC_reverseLeft();
	}
}
/**
 * 停止する
 */
void LDC_stop(void) {
	MU_stop();
}

/**
 * 右に反転する
 */
void LDC_reverseRight(void) {
	MU_turnRight();
}

void LDC_quickRight(void){
	ecrobot_set_motor_speed(LEFT_MORTER,60);
	ecrobot_set_motor_speed(RIGHT_MORTER,-60);
}

void LDC_quickLeft(void){
	ecrobot_set_motor_speed(LEFT_MORTER,-60);
	ecrobot_set_motor_speed(RIGHT_MORTER,60);
}

/**
 * 左に反転する
 */
void LDC_reverseLeft(void) {
	MU_turnLeft();
}



int LDC_isOnLine(){
	if(ecrobot_get_light_sensor(LIGHT_SENSOR) < LIGHT_THRESHOLD) return 1;
	else return 0;
}
