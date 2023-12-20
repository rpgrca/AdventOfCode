namespace Day20.UnitTests;

public static class Constants
{
    public const string SAMPLE_INPUT = @"broadcaster -> a, b, c
%a -> b
%b -> c
%c -> inv
&inv -> a";

    public const string SECOND_SAMPLE_INPUT = @"broadcaster -> a
%a -> inv, con
&inv -> b
%b -> con
&con -> output";

    public const string PUZZLE_INPUT = @"%dt -> fm, hd
%tl -> jk, hd
%vx -> kc, sz
%sz -> kc
%kj -> tl, hd
%pm -> tb
%fc -> rt
&tb -> sx, qn, vj, qq, sk, pv
%df -> bb
%qq -> jm
%sl -> vz
broadcaster -> hp, zb, xv, qn
&pv -> kh
%gf -> pm, tb
%pb -> hd, kj
%gr -> hd, pb
%gs -> kc, pd
%tx -> df
%jm -> tb, db
%bh -> fl, gz
%rt -> kc, xp
&qh -> kh
%lb -> zm, fl
%pd -> lq
%qn -> sk, tb
%gb -> qq, tb
&xm -> kh
%mv -> hd, gr
%gz -> fl
%js -> mv
%hp -> dt, hd
%nk -> kc, vx
&kh -> rx
%zc -> tx
%mp -> js, hd
%zm -> mb
%xh -> cd, tb
%db -> xh, tb
%sx -> vj
&hz -> kh
%vj -> gb
%zq -> hd
%lj -> fc, kc
%lg -> kc, nk
&fl -> xv, tx, sl, df, qh, zc, zm
&kc -> zb, xp, pd, fc, xm
%lq -> kc, lj
&hd -> hp, js, hz
%mb -> fl, sl
%vz -> fl, bh
%fm -> mp, hd
%bb -> fl, lb
%zb -> gs, kc
%xp -> lg
%jk -> zq, hd
%xv -> zc, fl
%sk -> sx
%cd -> gf, tb";
}
