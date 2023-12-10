
Dialogue_Example = CreateDialog(function()

    Talk("A", "안녕하세요.", "a_standing")
    Talk("B", "오, 안녕하세요, A. 좋은 아침이에요.", "b_standing")

    if CS.System.DateTime.Now.Hour > 12 then
        Talk("A", "무슨 소리에요? 지금은"  .. CS.System.DateTime.Now.Hour .. "시 인데.", "a_standing")
    else
        Talk("A", "그러게요. 상쾌한" .. CS.System.DateTime.Now.Hour .."시 에요.", "a_standing")
    end

    Talk("B", "하하하. 이제부턴 뭘 하실 건가요?", "b_standing")

    local select = MakeSelect("B", "b에게 무엇을 한다고 답할까?", "b_standing",
    {
        "잘 거에요.",
        "게임을 할 거에요.",
        "모르겠어요."
    })

    Talk("B", "그렇구나. 잘 알겠습니다.", "b_standing")

    if select == 0 then
        Talk("B", "좋은 밤 보내세요.", "b_standing")
    elseif select == 1 then
        Talk("B", "열심히 게임하세요.", "b_standing")
    elseif select == 2 then
        Talk("B", "무계획도 좋은 계획이죠.", "b_standing")
    end

    Talk("B", "저는 이만 가볼게요.", "b_standing")
    Talk("A", "안녕히 가세요.", "a_standing")

end)