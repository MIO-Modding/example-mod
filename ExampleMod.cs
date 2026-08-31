using MioGame;
using MioModdingApi;
using MioModLoader;
using PolyHook2.API;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
namespace TestMod
{
    public class ExampleMod : Mod
    {
        public override void Initialize()
        {
            Hooks();

            //Example .gin Patch
            GinPatching.PatchGins += () =>
            {
                GinPatching.AddGinPatch("flamby/assets.gin", Path.Combine(GetModFolderPath(), "assets_override.gin"));
            };

            //Example trinket
            Trinkets.RegisterTrinket("SILLY", 5, "KINETIC_CONVERSION", Trinkets.Placement.BEFORE);

            //Example localization registration
            Localization.LoadLanguageFile(Path.Combine(GetModFolderPath(), "localization.json"));
        }
        private unsafe void Hooks()
        {
            //Example Hook
            On.MioGame.On_Game.fixed_update.Prefix += Fixed_update_Prefix;
        }

        private unsafe void Fixed_update_Prefix(MioGame.Game* __this)
        {
            ref var mio = ref __this->mio;
            var str = Util.StringToMioString("TRINKET:SILLY");
            if (mio.has_trinket_equiped(&str))
            {
                if (mio.node != null && !mio.cutscene.active && !mio.walk_bot.active && mio.hook.state._value == MioGame.Mio.Hook.State.Inactive)
                {
                    mio.move_by_slide(new MioGame.Vec_float_3() { Base = new MioGame._vec_storage_float_3() { x = 0.1f } });
                }
            }
        }
    }
}
