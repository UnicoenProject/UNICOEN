function effecton(_this){
    if($(_this).effect != null){
        $(_this).effect.cancel();
    }
    $(_this).effect = new Effect.Fade(_this, {
        to:0.7,
        // delay:0, // 開始までの秒数 
        fps:60,
        duration: 0.1,
        beforeStartInternal: function(effect) {return 1;}
        // , //下の行を追加する場合はカンマを忘れない
        //ブロック内が空だとテストが通らない 
        //afterFinishInternal: function(effect) {}
    });
}