function effecton(_this){
    if($(_this).effect != null){
        $(_this).effect.cancel();
    }
    $(_this).effect = new Effect.Fade(_this, {
        to:0.7,
        // delay:0, // �J�n�܂ł̕b�� 
        fps:60,
        duration: 0.1,
        beforeStartInternal: function(effect) {return 1;},
        //�u���b�N�����󂾂ƃe�X�g���ʂ�Ȃ� 
        afterFinishInternal: function(effect) {}
    });
}