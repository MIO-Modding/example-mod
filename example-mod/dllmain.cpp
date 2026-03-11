// dllmain.cpp : Defines the entry point for the DLL application.
#include "Windows.h"
#include <stdio.h>
#include "mio-modding-api.h"

DWORD ApplyWind(LPVOID lpParam) {
    float time = 1000. / 60.;
    while (true) {
        Sleep(time);

        Vector3 pos = ModAPI::Player::GetPlayerLocation();


        if (pos.x == -1.0f || pos.y == -1.0f || pos.z == -1.0f) {
            continue;
        }

        Vector2 offset = Vector2(5. / 60., 0);
        ModAPI::Player::MovePlayer(offset);
    }

    return 0;
}
extern "C" __declspec(dllexport) void ModInit() {
    CreateThread(nullptr, 0, ApplyWind, nullptr, 0, nullptr);
}
BOOL APIENTRY DllMain(HMODULE hModule,
    DWORD  ul_reason_for_call,
    LPVOID lpReserved
)
{
    return TRUE;
}