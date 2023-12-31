--Talk, MakeSelect, CreateDialog를 전역으로 선언. 다른 파일에서는 다이얼로그만 담을 수 있도록.

local util = require('xlua.util')

function Talk(pTalker,pTalkLine,pIllust)
    local talkLine = CS.DialogueSystem.DialogueTalkLine(pTalker,pTalkLine,pIllust)
    coroutine.yield(talkLine)
end

function MakeSelect(pTalker,pTalkLine,pIllust,pSelects)
    local selectLine = CS.DialogueSystem.DialogueSelectLine(pTalker,pTalkLine,pIllust,pSelects)
    coroutine.yield(selectLine)
    local handler = CS.DialogueSystem.IntInput()
    local inputHandleLine = CS.DialogueSystem.DialogueInputHandleLine(handler)
    coroutine.yield(inputHandleLine)
    return handler.Value
end

function EndDialog(pResult, pText, pLang, pProgress, pNextMap)
    local endLine = CS.DialogueSystem.DialogueEndLine(pResult, pText, pLang, pProgress, pNextMap)
    coroutine.yield(endLine)
end

function CreateDialog(func)
    return util.cs_generator(func)
end