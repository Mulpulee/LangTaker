C_1 = CreateDialog(function()

    Talk("C", "어머... 이게 누구신지?", "C_Normal")
    Talk("C", "오랜만이야들?", "C_Normal")
    Talk("C", "이 귀한 곳에 누추한 이들이 오다니... 단장을 좀 더 할 걸 그랬나.", "C_Normal")
    Talk("C++", "...야, 미안한데. 쟤 한 대만 패면 안되냐?", "C++_Normal")
    Talk("C#", "되겠습니까...", "C#_Normal")
    Talk("C", "...응?", "C_Normal")
    Talk("C", "못 보던 사람이...", "C_Normal")

    local select = MakeSelect("C", "못 보던 사람이...", "C_Normal",
    {
        "난 별 거 아닌 사람이야.",
        "처음 뵙겠습니다."
    })
    Talk("C", "...재밌네.", "C_Normal")
    Talk("C", "뭐, 손님이 왔으니 응대는 해 줘야지?", "C_Normal")
    Talk("C", "다음 스테이지를 통과할 수 있을지 기대되는걸...", "C_Normal")

end)