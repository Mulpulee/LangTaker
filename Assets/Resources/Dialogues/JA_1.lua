Java_1 = CreateDialog(function()

    Talk("Java", "...뭘 그리 쳐다보십니까.", "Java_Normal")
    local select = MakeSelect("Java", "...뭘 그리 쳐다보십니까.", "Java_Normal",
    {
        "그냥 있길래",
        "마음에 들어서"
    })
    if select == 0 then
        Talk("Java", "그럼 갈 길 마저 가세요.", "Java_Normal")
    elseif select == 1 then
        Talk("Java", "빈말은 하지 마십시오.", "Java_Normal")
        Talk("Java", "보아하니 옆에는 JS네요. 어쩌다 동행하시게 된 거죠?", "Java_Normal")
        Talk("JavaScript", "뭐야, 이거 시비야?!", "JS_Normal")
        Talk("Java", "의외네. 너를 옆에 두는 사람이 있다니.", "Java_Normal")
        Talk("JavaScript", "야, 쟤는 두고 그냥 우리끼리 가자!", "JS_Normal")
        Talk("Java", "...불안하니, 저도 함께 동행하겠습니다.", "Java_Normal")
        Talk("JavaScript", "싫ㅡ어!!!!!!!!!!!", "JS_Normal")
    end

end)