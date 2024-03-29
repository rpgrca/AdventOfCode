namespace Day25.UnitTests;

public static class Constants
{
    public const string SAMPLE_INPUT = @"jqt: rhn xhk nvd
rsh: frs pzl lsr
xhk: hfx
cmg: qnr nvd lhk bvb
rhn: xhk bvb hfx
bvb: xhk hfx
pzl: lsr hfx nvd
qnr: nvd
ntq: jqt hfx bvb xhk
nvd: lhk
lsr: lhk
rzs: qnr cmg lsr rsh
frs: qnr lhk lsr";

    public const string PUZZLE_INPUT = @"qbx: vzd jrc jzl vll
jhk: scv xkp mjn
tqb: jgm qjn
gff: pmg fcn jpd qgc
npq: xgz sfv lhf
vxs: szs
nzk: thm bgr hnp bgt
ddl: jpx pjc
xvb: fzj thm qfr rfd
bbn: fjq kld gmm gjc
qdt: szn
tpl: jzt ncg
hrz: jhb ttm mms xpv
jzg: xxr
vpd: vqg skm jrm
nbn: jbh fkc vtc
cxr: hld
zdg: nqr phj
ldr: snq njr jvp dcd
ttf: jrb jch
ldt: scq bgt
qhz: zsv
pls: hrt lzj jzg
xbm: dzp
srb: xvv rnf mpg kxz
qvs: pzm sth
bxn: jss
xft: ltp mkq jqs fds
phh: rgl vjp bpx
hsz: qxj pht nmc ttn
mqn: xrs bqg ddz vdn
xvv: lzn xcb
pvl: jfj
skr: pfk zdg xff
nlb: frd tvb qmk sfp
sxz: bff xpx vjp qkv
tkz: fbv fct xhn fxj
nlc: rmt dcs vbt
ttl: bkq psx
jdz: rtr cpq rjk qhf
rkc: prr msr zpg
vqk: xpd
jhg: rbt
fgb: txx
tqv: qtr
fjq: mfz bjj pkm
lxx: zxl skr mrb cch
nrg: kfz xmf
qgm: dxn jzt rrg
thk: xcr sqn ttm mbs
hvk: zfp
phz: bgr mmm hdp vnn
jtt: xvt nln
blq: dqr nxv slg ckf
mdn: vxs brq qpb
zmp: phz lfr ghv cmf zcm ncr mzb
tzx: qtr
fjh: zbt xxr xpd zkg qxm
rjn: zkl vth mhl
jrn: xgz ckf
llj: ckk shz ztr
dcs: bmp
dtf: ddx ggm czv qck
ncn: lmt cnd drq sqs dqp
thn: zln fbv hmz vqc
cbx: jcl vlz xff dgc
dtx: bsv pzf
mvh: ftn ccj tqx
tdk: dxj jzg
nql: qpm glq sdl dzp
jjp: fgb zbj bhz kjn
gdx: gvk hdp
drq: zvm jbt sxt tlg
cdt: njr nxv
jpr: lgn jkc fkv
tvj: vrx cbq fxj lbx nvt
drj: nqr gqf tqs ngx cdv
cht: vfq zgd
zsq: tvl dps zxz
gxm: kfn bkj bql kfm
kjb: rlm slp
jzl: qbz
vrr: xph xrj svz mnt
jlq: bqn tbn
vnv: xqf bms krc tzx
kfr: kvj fbl vkp bvc
cxb: kvj mrm zln fnz
mmm: mfz
czb: jqs lbx vxs
xmf: dvs bvc tzj
kgh: tbn vxl bmk
fmm: bqn knp
ktf: nmf vbs rql kbb
xls: dhc
tks: nmf tkf kfj qvs
mcv: hjx bdm qbr
bsm: xsj
txk: fll jbc
cck: lxf jtt dcg xlc ppc
lzh: dps
tfg: zjc
qjp: nkq xtj btg gqv hlr ktk
pkm: ftn
vkp: csh qvz pkk ssr vqk
slg: bph
hgj: rqp mvt
htv: cmj xrp bxn glp
vln: hnp sfm
grr: slp nnr vbh lnz zgx
mqf: mjg
hlr: ddl
sls: qtq ndh
nrj: dpf qpm
gnm: hjx drl
jkh: sbl
dxg: dfd zqj tqd crg
zkv: brd xrs mnq jrn
pzf: mkz rqp
nnz: zvs zst sgl zhr bsm
qhf: prd jrt zzz
dxm: gxl qbr
tgc: fpd nbs
stl: cst qbz ptt
xlc: pzm
zxv: cls
crf: ftp ztp qml nxq rnl
mgq: tlc vlh jjg vln vtc
gqn: zbr ttc zdg xln
ppk: mkx gdc bdh
qgc: mvt rkd thh
mhl: hfl fbc
ttc: bmf
qhx: rvb qkv fgx
jmq: xqf
dfb: jkc ttj xtq
hhv: qdl kkv gfn
sbz: lzh drt spl kjn vqg
bnd: msc
cdv: ndh zkg
zmn: phm kbg xjj
fbl: slh
tbq: qdr tzx rhx
tbg: fdj vtc
gdz: rpx vkb jhs lbq
flk: tks fps
njg: bmp
msn: lzj
sxh: dpj zzj lnk qfl
xnq: srf
fdb: jrb jrr gmv kfh
rsp: nzz
gcx: xjj dqx knt
mdp: dhc ptf xzc frk
tlc: qck vmr
xqz: skm dpd
phg: fts tpv fjt mxf
ftz: sbm gbt qzx
cch: sjg bmf hjx
drl: qrv
hcm: qqc jrm
bbf: sst
lmm: pcj mhq
rhk: bff msp nsx dvl lsn
ptt: mnb
gpv: hpf hmz
ktn: vqk nqj kkj
nfc: fhn
rbh: lhq cbl zlr mtl
tzd: kgc
rts: drl vvc hdx cnx
bkh: cvb mvn tmm mrb vsh krs
fqv: kkv
vhp: dps djf snn crv kfl
frg: nnj gfn
ssr: rbt lxc phj
rjq: mdp nxl czt xvt
ngt: cfp qml
jpm: jmb rtm sbh knt
dqx: zfp
lgl: dsc hgj
nff: qkr brq phl pfz
fkc: dhl
xpv: msc zjc
jjr: cqp spn nsp zdx flv
ltv: sjc hxm mpz rsp
tgb: flb knt hmc
jzm: szm ccl
zbz: sgs bzn
fnz: jnz gmq cdt
flv: kkz xss
jzc: pff pdh nkz snl gqv
mvf: dpr brv flh mkt mvn
flj: hmr pnk phb
hvs: mhm gqm
nnl: zbt
zhf: hzk ksl
rgv: vrq csm qxq gbs zds
qmk: flv szl mfr
qxt: fvm rct fvl sfm
tsc: lvz szn
pkt: xfh
zml: qtr kdc dmm mqf
kgl: mpj xgl dbm
tkc: nmd fvj
pbc: dkc btt vhl
fvr: pkh sls hxz
jmp: hdn qpb tll qsv
tzr: mfl ppk
hhb: hrt nmf kjn sgd
ghv: mrr
zlr: jhn rlc
mms: bfl pkf
xss: qmh mjn
gpt: vkb cjx
kcq: jbc flh
sbm: qkv
dtp: mrx jhg qhk sxc
rdb: xzf
pnr: lkq cmd jcx gvh
xdn: mrt
lnc: hlr mnb zsl
hkj: blq qfr fqd
mrx: lsc
shz: zgd rll vnn
xmh: xrt gdk sbm kgl chn
rdp: ddz nvt kgk tpp
rtv: msp flj fjh pzb
khc: mrr rvb mfb
bcd: ttp jrl mkz lqz
cmj: zjj vbs
qhp: xqq
ztr: sjc
pkf: tdq
hpc: xbm rgj
nxk: nkq fhn dqc ltx rpx
sht: krx rvt jrr lvz
ppf: pxm tbg fvj kss
ftd: mmd
ndk: txz dgt sjs
glp: ttv hrt ghr
xhn: vbd bbb vjj
kzc: khf fdj bvm gbt
gpb: lcd thh sxf
ndp: xnn szs ptt
qds: tln qtz trg rrg
jzh: jrt msn bxn zts
xzb: rqm rkd tqx jnx
lvt: qcg bbf jcx mnb
xpx: ccj fzj
nlg: qch kxn thq bnc
tjv: hkk kkm vds lvs
vrl: hsn sgs
bmx: qhg ptz
hjv: mrt
dqp: gkh lqt
qkt: xsk xtj jbh zsm xvv
pbq: hcm xkp zrg pfk
plm: dch zxl mrx
bdm: lsc zbt
rkm: cjq
ndh: mfr fzt gpd
zhk: pkt bsc
blh: zln
lkg: nvb sbh fzt jpr
nxl: rnz hsj tfm
qbv: vhl zdt
mxg: mfl
sdl: fds vdn dqv
lfs: qlg vkb pvl
prb: sxt nrx
xtc: jbd lmm
kdx: czz
qlb: xnn zxv vbt jgg
ppg: zgc krs zbt
bzp: zgg crd ptn qbx
xhx: pkt gfm vbb rsq
zbj: phj kzl pfk pmh plm
zhr: qck
gmp: cmd
kxt: pzm
ghj: hhx
bqn: cvt
gdd: pcj kpx kxh
tsx: ddz bfj kvj lmt
krs: tbk
ggs: hjv spn ltz sth
xrr: pzs qvz qhp dcj
snc: krc
pxm: vbt xlx
hsn: tts
nvj: hsn tks
tnq: mgg xpp nxl
dxk: gxl
hdl: bsm pzp ltx nnr
xkm: tfm bbc phb pzb
hkk: gcx gfm bxm cbx dxn
njr: fbr
jxk: cxr ktz nrc dkp hht kfz
jrl: nlr rpx bkq btg
kjv: kjd pls flk hsb
bjj: xrs vnn gsr
mrt: tfr
npm: cbq
gjf: bsv qvn zhx vjj
kjn: tzr
gqm: vlx fbc
vhl: fxt
ssl: vbs lts xls zdg
xsl: qck slh
dlq: jbd qnn vbn btk
qxr: xnq gcx xdn svd
hjk: hhm tvb
xrp: sdf xcr jxt
xvg: pbv sgs vnf ttr phj
fgj: qjb kbb ktn zjc
gnn: vzd tnt qbz
pdt: fcl tnt mfz dgs ztq bzz jgx
psx: kfx
rxg: gkl jbd dqx
cqq: lmm xff lvs
qnn: chs zgc
zts: qnr hvk zdp
plv: kzs kfx qmf qvn xgl sbl
hkb: brz xbm qsv
nmd: kvf htr fzj
rpp: mdk kmf mmd bfj
vml: ngs fqv kph
hls: plj rrc
tqx: ddx
vnp: qdt mqf knp
mln: ztr
xtb: jzg
dkh: gcz dcg
sdn: nqj prr
pmp: jzm txz fhn dtf sxf scq
kmm: fzj zhx dvs
fnt: nzh
ncd: ldr khf fqd qlg nvt
qvx: cmb vbd pll grz jhs ntj
lzn: cxr jgt
pht: qkv bzv
zqd: frk sgs xjj gdd
ngd: gpq ghd zmx ndk
gbs: ltz tfg phc tvl
zfs: shc mhq ptz hrs kxt
qmn: dbh klt tvz
gmv: sdn gcz
bxc: rxz nrl qbk nvj
dlf: jjg
gpr: bjc zst
bbb: rqf
zxz: jpn
rqz: psx vkb sst qcl lrh
ltx: hnn fjs jpd
lhl: vqc ddx gvk nlc
xcb: znd
hmh: qhr
qbk: qdt hmh glp lsc
bhl: rqp kdx fzx
zmk: rlk jfj
msr: mxl lxc hns nnl
mtl: dgc xqf
fzr: qxq xdg lxf
ccn: blv fhs hht
xth: hnz kph mbj mvb
xsx: lvz
bjs: tqv xfh vmx qkk
grf: qmf cnd fct
zdp: bxg mbg ltz
mhm: vtc
rnf: gjc
fkt: vln sdx nvt qvx
pzb: ncg
jvj: fjg tvb
bpv: dch prd xkp kfj qgz
rvj: vhr znd fbl tcf
sth: kfh ttr
ccg: cbn npm zxv
trd: xsl qmf pvl jkh
qxj: vlx pzf pkm
zxj: bgj rjk fmm ksl
rnz: vgn jzk szl
bhz: tbn fvz qcf
ghr: ltz jtf dvz
rkd: fvm
msk: pkf mnl cnn
trg: qch
zvm: qmf xqd
zsm: tkc vjp qpb
nxq: hjk mjn xss jzk
zbk: tpg
dcd: khf pht tnt
hmc: gdv qln tsp qqc
hfc: qdr
zjx: crd klm
crx: gtt xzb rrc
vth: qnj
tbl: ttf lsc gtc flk
bgj: fll
nxv: bph cnd
hht: czz
jch: mnl
qtq: tln xls
nmc: jjg plj
fft: gjg mtx crx xrj gbl vdx gpr
xxg: khc qzx dbm tvn
thd: crv zbr rtm
ttn: lnc cmf rsp
zsg: vdz rxg jss bmx lqs bqn
rqr: dpr jcl pls vmx
ghf: mjx jtf zbk
pdh: xfj qpb sbm
hpf: kgd blh mnb
nsb: lfn zzz zhm
tlz: tfj
cjc: ffr zhm xhj xjs fkl
mjz: fxt mrb jkf nqt
fhs: sdx lnl
fts: zhx
xqq: pcj mjx
vzj: bhr bsm dff
lld: slh mmm
cgl: bmx sls fjh pxg
lqb: bjc bck dcf kfz
ksh: dgk lqt
hgk: ttl brd rgl bkq
htr: vzd znd
ltr: hvk mtl djk
lvs: zjc
mxf: vzd
tpv: mfg qbq
qzx: cjx tpv
nhz: rrg
bdb: tzj gvp jpx xqr
nsk: nrc nvt nlr
jrt: shc hnt
dln: pvc tln zlv
hgm: xnp jzl svb
dmz: mnq cdk
gzt: gfr zjf bvs
lqd: bgj gkl mtt hng
hdx: zdt ckr
pzs: vxl vpd jxt
sks: tqb vbh chf
rbt: vkg sjg
tll: sfv nsk
txt: skm xzc dvz mjx
fdj: ccl
qsp: hnp vzd sxt
zqf: xtb vnf zlr mkm dcg
lnk: lpn zbk
bnm: gnn jnr xgt xsk phh
zgg: pmd hct
dxx: mmm
dsc: rmt xnp
hhz: sdn srf jss nvb
fmh: jhf glz hls bfj
zzz: fll txk zjc zxl
cll: szd nxv zvd
jhb: kfh
vgn: zkz
hcq: sjg jhb gnm ctp xtc
zrq: ftd ttp qhz
sxc: qdk
rqf: glz prb
qxq: tmq qbp
vhr: jqr tfv xqj
fkv: fgb
xvj: jdl nxh hbh llj
lhb: xmr tmq ncf lfn
lhq: sth qjb
glx: zsq ghf hhm
hbh: ztr
qkk: szn
gbl: cmb
jgg: sxf jhf fzx
dqm: bbf tzq pll skg npq
qln: bvs
ncf: hcb xpv nsp txx
xjm: thq npc ggv trf
mrj: xjj qfl czt thd
qpg: dqp zvd fvj szm dbh
tvb: htm
klz: zhx npm thr
vkg: djk pmh
ctl: xhn dcf
zmt: gnx zkg dvz dbb
bhd: vds bnn ztp xls
vdn: mkz
xmc: dln kkz pqc thq xkp
tfp: kph fcx bnn
dcj: tqt lmm
bfp: zdx kkj kkz
jpn: txx
zjm: brd klz kgk
jcb: phl bll ttn xcb
psz: cbr zlv cvb
rlc: zhm qhr
ljx: qgc xzp pff ckf
vlx: sfv
nrx: hbh
qsv: bgt
xmj: tdb xlx
vmx: fjg
vqv: mdn nhm gfp qpm
xvt: bsc fcx kxh
tbn: nqr
mkm: mrx hzk nmf
fqd: lqz
bkj: ncg zdt
kgd: xgz
hqr: xsp hgj scq gvp
prq: jrc hkj kdx jzc
qvh: mvb phb jbd
bnn: shc ckr szx
xpd: zjc
xkp: czt
qml: tbk
vbd: zsv
bbc: hzk ksp jrm
rqn: gbl ncz txq kjb
gdc: tdq qbv
gbv: btt jtf bnd mvb nhz
vkc: zqm dxm bmk ngs
sjs: ptt njg pjx
nzz: sst brz
ppr: mhm zsv
hdp: jgt
bnc: cvt
ctb: kll bhl dmb dlf
lpn: qdk
nms: dcs dff sdj
nkz: fhs kgd
szx: cnn qhp tmm
dss: ztp ttm hvk
czm: fxm hsb xvt zrx hns
drt: qhr csm
fvl: hhx xvv zjr fnt knr
kjd: zkz fqv pkt cfp
tkx: plj
gzb: ggt dpf sxf dbh
rjk: msc qkk rvt
jnr: ztb ghj
pqg: dpr fjg
lhj: hcm hjv vds qxm xnq vkc
lqp: tcz xkm dln qdk zbz qmh
zvs: gfp sfm
fxj: rbj
gfm: dkh kfl
kkm: tfg sdf
cnh: thr htr fjs fjt
tpc: dzr zmp ttn fbr tzd
dsz: ssf dhc
rck: qhx hxm hbr kbr
bqp: qkc spc tkx
gjg: dxx qcl
lnl: jgt mpz rfd
lxj: fxj vsg phz
mlj: ktz gjf kdp
lbg: nqj mrj xpd frk
xlt: dlf gfq cll qjp
mkq: kxp rnf
ntj: xtj
plg: tkc pcn gzk sdx
tjs: lvz dln kgh vdf
pkh: xmr pxd
mvx: mhl gpv bcd rpl
mzg: bjj qvn rkd sbl xkj cbq
kss: pll bpx phz ngh
ptf: jkf lqc lvs
jns: fmm knp
ffd: nkq xsp gfq
kdp: gdx
nnj: jpn
jlz: dpd hxs tbn
mfb: fvm
qcf: xjl pmh qjb
kld: lld jbt stl
krt: vdz fjg xtq txl
ldm: phm
ddk: lfn clv kfn tpg
vlh: gbt gpr szm chv rqm znj
bff: mrm thh fbc
dxn: sds htm
ttm: kcq
pfz: zjx crd gmm
xgz: vnn
sxf: xsj
xkb: zrx trg
fkk: bgd kkv nsp
sfp: fmm nhf
qjn: sbl
xgt: mdm fmn
hkq: hsn pqc kfl
zqj: nxh
qng: bgj
tts: zfp vkg pfk
ckk: mns rct jhf
jzs: bkq tzd svb xcp
nbs: mvt jgm
rmf: zjr zcm lgl sbl vqv
vdf: zkz jmq
mvn: dzj bnc zxz
mnk: pkf snc kdc
ltp: gsr ngh qrj lld tnh zvd
gjv: vlx vng cst vrt
mdk: jxr pxm
btk: zkz sls
tgz: mkt hgs zzz glb
sfk: njg rlm
vsg: bhr nxh
kxz: ztq btg
qpb: mln
llt: rbj xzp njg dqr
ktk: nlc bsv
cxd: pvc fll zkz
zfc: ddx njr
lsx: pzb ttr bbc hhv
rrz: qbq jcp psj fcl bjx
rvg: ccj nrj lcj
fcn: fmn bck dzp zxv kmf
dvl: krx vrs bzs
xtj: qcl
xht: nmc cls fkc
kkj: tkf
zrx: zrg tsc
zrg: rvt
nmj: xpb zjr ggt
csb: gpt fqd bbb pmg fcl fvj
mxx: fds tfv tlz hdp
xfj: nfc mrn pvl
mgb: zfp bdz mnl frd rdb
bxp: phm rtm qdl
dmm: cjq spn
zqm: vhl vrj
psj: gvh
hxk: lgn nvj vbb jpn jbc
htm: bsc
krd: slp bsv mpj tnh
jzk: ncg
cvg: rbj vzj fgx ndp
lfz: hng
slp: zln
ctq: jlg dpz tqv
gmj: nmd dzr qnj qrj rnq jzm
mkz: hct
rhx: xzc snn rkm
rgj: vth slh
qdp: xpb
tsz: rlm gmp zst qsd pcn
gvp: thm dgk
dhf: qbz dsc qsv cht
xmr: cnn
kfn: fmm crv
nbg: ddk qvs zhk rkc nfd
ssd: nzq shd tvz gpr hvs
bln: npn hkq rsq
qxh: lvx cnd spc bjc
kll: pxk sxt txz zcm
kxd: dfd cls bhl
tnt: bqg
chf: sbm nrj
bdz: xvx tfr
qdx: nrl dsz hfc pnk
ztp: gtc
ftn: jbh
vll: bph jfj
tmr: jch pzb htm
cvb: xsx
ffn: gzk spc nzh xbm grz
spl: zgc bms
qtz: zjf hdx hzk fps
xsn: ngh mrr qcl sjc
qlh: dgk xlx ktz sks
cpc: ttj btt vbn glx
plk: qch
jrc: lhf nhm
nht: qml jpn xtq
szd: sfv
pjc: hld
spc: xph tkx
lhf: hfl hnp
rfz: thm jnx bjx rpn
gzq: bdz qrv frg gjd mqf
rzc: rgf mdf vmr rzp
fjn: mtl ggv
jzn: nhf zhf rdb
zhh: qqc
shd: jgm dzr xpx
knr: vfq mrr
svb: khf znd
jvk: gpd mfr
jqs: txz
vxk: pmc qxm ltz
cfm: ctl fbc mfz hls
mrq: lzj vqg xtx mtt
qdk: jbd
rvb: mpj
njz: zkl gmb xht
qxm: lxc
ljg: zdx fps qng fjn lzh
dbb: mjn cjq
cpq: snn qhk prr
kvf: fzx qvn qlg
hns: kfl
nqb: xtc fqv tfp ggs
xzf: fsq bdh lvs
qgz: xbt jch
zjf: gqf zlv
xhl: qrp pxm lhl
qmx: cbr cxc tdq
bzs: prr tfr
jdx: ljj tbk zrx nxc
sqs: qlg fzx nmc cmd
ktv: ttb nzz qbq xhl
xts: fgb kkz vxl bdm
hcl: jxk kdp tkg sbl
bvx: xzc sdc dcj qch
fkl: vnm jvj
fhz: trq snc hjk tbk
pff: zkl pzf
mjc: kfh jlg lfz lpn
kbr: pjc xsj
hsj: pst bgd jrr
fpk: qmh qbp ljj sqn
qls: djk pcz gml trq fsq
hdn: fvm kdx jdn
ncz: nfc zpz
chn: jrn jcp czv
khf: sfm
brz: rlm
lqz: vkb zvs
tqd: dxx
rhn: xfd rpl zsm nrx
kfz: gfq
zdt: ttc
spn: vbs mhq
hng: bvs sql
fbg: jmb frk cfp bgj
ptn: blh gsb zjx
szp: vdx
qct: dqv npq gmp ccn
fjt: xcp
xrt: vrg sdj dbm
mbt: gsh htm xxr
nzq: cnh ztq dvs fkt
xzp: fts
jgq: qdp lkq
zxk: cfp lgn zkz zbz
ljj: lhq qrv
qkr: ksh xph vqv lhl
rsq: jtf pqg
rbj: mns
gch: sfp mzh xxr tzr nnl
hxm: bvc
jmb: htm vlz
rmh: hld
vjn: lts drl
sfv: nhm
ptj: rdb jmq ptz dmm gqf
lsn: zfp gmv
hxz: qng
tmm: cvt gqf
fsq: fgg
dmb: klt mhm zsv szp
rpl: czz
sqn: xxr msn xcr jvj
zzj: nnl gxl kxt
cnn: gtv
npn: phm txl rrg
dsq: hmh pcj txl lfn
bct: nxv qkv
fpz: pqc jhk jns
qjf: fpd phl jxr qsp gsr
kbg: jtf ttv
gnx: fkv nqj
xsp: vmr
gtf: fpd ncz lbx zgd
kgx: pqg hzk knp zmt xbt
tsp: vkg mrx pmc
vdj: txz fhn xcp hzx
jxj: ppg szx gpd zbk kph zxl
nzb: ffd hbr xvb hgm
fgg: bnd hhm cvt
tgf: blh xdx vqv mfg
tpp: dgs lfs pjx zmk
hbz: gpm txl vrs
txq: qbq hfl lnl
bgt: szs ftd
hzx: mmm scq ddl rxs dbq nlr
kvr: jqr pvl crd lpj
qrl: mjg nvb tdk ldh
ftp: jbc jrm
xqr: jhs mdf lnl
xkj: rqp cjx mfb
mnt: rfd mln
gtc: crv cjq
vrt: szm ttb tpq
qhr: csm
xxx: knr jpd dhl
bpr: rqf lzn nbn gfp
lhk: ppr jxr mns jgg jzc
jnx: bvm kgc rll
hhg: mpz bzv jfj snq brd
vng: vxs lcj cmd
ddz: rct jpx
gsg: qrj dxx tqd
zjj: snn
kfm: jcl
lxf: mrt
mkt: cxc vml jrb
qqf: tgc jdn ftn
mmd: jbh
zkg: kxt
fgf: sxc hrs trf rkm
jnz: ckf
kzp: bln cbl rhk tbq spl zjj
tcf: hqz ckk dqc fbl
qnr: gqf psz rhx
cnx: xkb cvb
sdx: scq
gkh: njg nnr blh
zrr: hct zvs sfk dvs
ghd: xfb phz hhx
rgl: mrm tlg
qpm: fvm
flh: djk gml
cnb: zfs hrs qhg bms
jsd: hkq cjq xjl dsz
mdm: ppr ghv kxz
pcx: nkz gfp ppr vsg
svd: txk
bhj: gqf phb pxg mvz
cdq: svd bsc
vxn: tfm qqc
cqg: vfq tbg hxm rzp
tvn: cnd
knt: mrb qnr
sjg: kfh dxm
xcr: sql
dkc: dxk szl sql
gzk: nbs
glf: jcl jrr cdq qln xpv
ktz: zpz
nnr: dqr
nln: fxt mkx mjg
fjs: qck dkk
tkg: qzx dqv klm fjt
hhj: sql bmk krs
qtn: rxg zds vsh szh cnx
lfr: xhp hdn gjc vjp
fgx: qjn pmd bzz
vxm: xdn cfs tvl ctk zdx mbs
qpp: fbn qfr dmz ldt vnm
tqt: frk sls
fbn: zsl zvs
dgt: mfb chf czz
brv: txl qtq frg
pdg: fjq bzz xmf nkq
flb: hng mbg vrj
bxm: mbj
rxn: sds qng kbb mbg
rqm: bsv
bgd: qml dzj
pfl: dpf gmm
sdc: ggv lhq qbg
rnl: rbs jpr fpk
xrj: hnp sst
kqc: tmr lnk lsn ncf
crg: jqs nxv khf
smq: bbb blv klt rlk sfm
dhh: jnr ltx dfd xfb qhz
bvm: jdn
jgx: jpx rrz dbh
thm: kfx gjc
qcx: psj mkz fgx kgd
qsj: gcz mxg ttg mzh
phc: fxm
vdz: zbr kxh
gfn: bkj
gzn: vgn rql tzx bjs
glb: hjx tpg kfm
trl: pkf thq
jhn: fzd
lml: lxj cnh jgq gmm mnt dqr
fpd: plj
gpq: jbt vjj
vbb: ttv dxj ggv
qrj: skg
fhq: lfz gsh fkl bdz
ztk: jbd jhb fqv
vzh: xhp gbl ghv npm mdf
nxc: hxz vrj
xqf: gpm
chs: mkx mjg tqt
xph: kjb
hfn: ztk vnm mfr lvz
dpr: bxk
mhq: kfj
zmx: ccj
snq: dfd zfc
rbs: lzh pcj tpl dpj
lkq: dkp
kjl: lcd rvb bct psj nrc
kkh: ttj dps qkk kcq
sbh: fbg hjk
hrs: svd msc
dkr: hvs mkq glz nnr
kdc: tvl mrx
lcd: dbq jgm
bxg: qmh lqc
rrs: rvg ppf jxr
bfl: xts mbg
qhk: hhv rvt hnt
dqc: xdx gjg
ktg: mvt ghj tzj mzb dtx ctl nmj
bzn: mbj hnz lpn
hgs: kpx jzt cmj prk
vjj: bfj
vnf: mbg jvk
ncr: fds dhl pfl
kpb: tlc tvz tll zrq
mtx: bvc dff
jck: xtb gpm jhn msn
gdk: hdn dzr mlj
bll: mvh dtx prb
cbn: bhr vzs lqt
ppv: vnp knt plk nxq
zlv: kfh
kmf: czv dkp
pxb: qbv thd gcz
dgc: jss ssf
snl: hht jdn zfc
rql: dpr rnz
dzr: bbf
lbj: zvm lpj dkk vll
vmd: tdq kkj qdt
ntz: fzt vqg plk czt hhj
gfr: mfl
xjb: nxh khc fts pjx
dch: zbr
kzs: ccj hld mpj
vhb: zqj fdj glq ggt
xqd: cdk dgs mrm
xhj: qcd xkp sgd
vtb: hnz tpl hsn
pmt: fpz vtb sds nsb
pxg: lbg rhj rrg
nlv: ngt jmq fzr qcf vmd
mnl: dqx
cdk: mfg
zgx: fgx dkk rrs
tfv: zvs lbx bzv
sgq: rlm klt nzh
kpx: ngs
tzq: slh pxk zvs mfb
pnd: dxj gsh mnk xxr
pst: gtv
bjf: zhh jkc hmh
prk: dzj gml
vpn: bdm pkk hfc dxk
brq: hmz mrn
mns: fkc bqg czb kfz
fps: zhh
ggm: tlz tsx zdl
zsl: bhr
rmt: xsk fnt
hcb: fgb pkt
jvd: gnn xfb dvm zgg njz
ngs: kph
rlp: lqs xtb zmn kxn hsb
prd: phj
bqg: bvc
rxz: xqz vdz gxm lqs
vhg: kvj lqt hgj rpx
dpz: vrs xxr glb
mrm: ftd
gkl: bxn jhg fjn
xnn: jxr bkq
nzg: sxc qgz kxh vbs
jhf: ccl
rhj: ghf gfr szh
qsd: ntj pjc bkq jkh
fvz: lvz lmm tgb
mrr: xhp
jvp: lzn qck gzk
jqr: snl rqf jhf crd
bzv: slg
pmc: lqs
jdl: lrv psj mpz tvn kxd
mbn: dqv jrl vdn ntj
xpp: jns tpg
fcx: shc kxn mvb
mjk: dhl sfk rll hfl
nsp: pst
qbp: dfb
qdr: fxt
dpj: jss zhk fzt
cfs: cxc rtm
jcx: lhf
cst: vth jbt
ldh: qcf vkg rgx
vnh: vrj gdc qml qnn
hgh: ctq tkf jkf bzs
zgd: bmp rpl
gbt: zhr rll
zkl: jpx
xjs: csh mxg cpz
frd: hnz rkm
pfx: qfr tzd hct
bjx: gvk vnn
lcj: nlr
mrn: dhl jgt xpx
skg: zpz fds
cmf: fbr grf
csh: kxn zfs
tdb: ldt ktz
rqd: xsl qhz tlz szd sgq
djf: xqg mfr bdh
fxm: dcg mtt
ttb: ttl rsp klm
vnl: fbv gtr jzl ktk
szk: hlq rtv kfm jvk
bvs: ttv
fjg: nvb
sgd: ttg jnv
lsc: pxd ckr
mzh: kbg vnm
rpn: zjr gdx cht fnl
sds: szn
kpj: hns trf phm dbb
xgl: nms glz nrx xcb
djz: fbn pvl jgp ccj
gmb: rzp rrc hlr
mpr: pbv qgm zts hxs
dcf: kfx xjp
dbq: dgk
vnj: fhn czv rfk ngh
ppc: pmh msk qvh trl
xsj: jjg
fct: tkx tfj
nhf: bxk
dqr: hdn
pfg: xjl rtv jbd vdz
szm: qbq
tpq: rlk lmt
dbm: tqd
qch: ttc
pcj: pkh
qcd: qdr hrs rrg
vbz: jrt ttf ksl cbl
rfx: vqc lgl mdf zxv cmb
rvl: jrb btk tmq clv
xdx: mmd znd nhm
lqc: ckr
djv: qbg lvz gbs xmr lts
fsg: mpg xpx bmp fbr fqd
hnx: grr rmh fjq blv
lbq: lmt vrx
xqg: ssf thd sds ldm
jnv: dch bxk hhv
kdt: ljg hbz nvj jhk
mvz: kkj trg ntz
ctp: nmf vnh msc
xnj: pcz dpd lxc csm vlz
gbj: bxm jtt spl gnm
vtp: vzj zsl nrj cst
phm: tmq
hxs: pzb
kgk: gmm hnn gqm
nsx: qtr gzt fkv cdq bfl
mpt: xjj zrg dxk ltr
vzx: fqv jpn hnt ghf
lrv: jcp hsz nfc
chv: xnp xdl gpq
blt: tfg ttc hhm jzk
cdn: sgs mqf nhf gtc
tqs: mfl
bbk: mms bms zxz vqk hnz tnq
mnq: zpz slg
gdv: npc tks bzn
vbn: zhh xsx txx lfz jlq ppj
qqc: gtv
rnq: cjz jgq
ffk: bbf rmh rgj pmg
vcl: qdp vsg ttl ghj thh
rlq: jkc xsx tdk lfc
vzs: pjx dpf xqr
vds: dps
jcj: pkm gpt zmk hkb
xjl: bmf qmx
npc: vhl gcz
qfl: nnj fkv
dlt: mbt bxg ksl mjx
dcx: drt nxc bnc lxf
gsb: sdx ttl cxr dzp
ffr: bfp pcz jzn vjn
xqj: fnl bvm qnj
zxl: pkh
qbg: hrt
thr: bdb szp
cbq: dzp
mpg: gpv rxs ztq
bzz: zqj
zcp: kbr lzn tzj xsk
xdl: zdl rlk
cqp: xvx nqj fzr cdv
qhg: ngt cpz
qnj: cls
qkc: pmd jgp jkh
kbb: xtc
ptz: bvs
nqr: pxd
lvx: dlf gdx dqv nms mxf
rgx: vxn csm pxd dxj tkf
xfd: llj fzj bct
tmv: bql ntt ftp gfr kkv
rtr: nhz pzm nnj zhf
ztb: zgd zst tvz
vvc: vdf cch szl jlq
jgp: nrg mxf
bqt: qmf tdb dxg fqd
xln: xfh snc tsc
zgl: qgc zcm rfk pfl
nfd: dkh kdc xqz
qvz: plk trl
zvd: njr
vrq: gpd ldm mkx
lgn: nht
bpx: jxk ktk
tqz: zgl vbt lcj
xkz: qpb zjx szs dgs
dsm: rct zpz pjc hnn
ppj: plk gnx hng
kzl: cbr vrl
vlz: gsh
xtn: qdp zjm cdt ftz fpd
qcg: bqp ksh xmj
hkv: vnp pbv qbr
sdf: qjb vxn
kxp: znd rll qqf
sgl: brz qjn gfp
lts: bmk hsj srf hnt
zdl: hld
tfm: cfp
bck: pmd klm gmp
pkq: xqq xln msn cbr tqs
mxl: bql fkk qdl zfs
mzb: lkq
pnk: zhm bgj
skm: vxk
pcn: jcx qbq
frl: kkm nxq jhn jhb
vbh: btg nrj
hct: xcp
lpj: hmz vdx
tlg: rsp zmx
gvh: sdl dqc xdl
glq: glz lcj
ljb: grz gjs tfj sdj
dmk: pcz vbs xnq pmc krx rgd
rxs: ptt
lfc: qkk ttg ssf phc
fnl: spc hbh ccl
jlg: sfp kkv
ntt: zjj gml lfz
zds: vrl nsb
hsb: xlc
dkk: jrn ftn
jcp: psx nrc
vdx: dkp
krc: xzc
blv: hxm vll rzp
gtt: xdx cjx nzh
sjx: vbs krt qmh hmc
hbc: crx jqs bjc lbq fnt
dvm: kgc xzp qsv
zpg: bxk dpd kkj
nrl: tln thd xpp
msp: xff xfh
xtx: cxd vgn hmh
qgs: cqg xpb mfg jhf dmz
ttp: mhl bph
bdh: vxl
ttv: tfr
qrp: sjs sdj rmt
fpt: dvs fbv kmm rpl
fmn: cht tqb
gtr: hpc grz dqv
nqt: hfc pbc ttr
pzp: pfx tvn gsg
bql: mcv
gqv: hnn
gmq: szd stl gfq
vqq: vqc xhp rnq xsp kgk
scv: hjv mrt
szh: rlc qbg cxc fzd
bgr: sst sbl
khm: zjx czz gsr tqx
rgd: vrs hhj xkb
sqv: vdf hxz cpz btk
vsh: flk jns fzd
svz: dqp vnl xlx jnz
jlj: szp ccg xgt kbr tqz
jxt: txl rkm
vrx: vfq xpb
qdl: rtm
rfd: jhs
ksp: scv ztp dss
cbl: bsc fsq
xxv: tkx xxx gsg rrc
fqb: qhp gxl cqq xjl rjk
vql: glb pbv chs gpm
cnk: vrx rjn bjx mdk
jfq: qrv fvr bjf kzl
cjz: dgk dbq skg
tcz: rjq jkf hdx
pvc: krc bmk
xbt: ttj trf
hqz: mtx tfj nrg
hlq: xvx dhc fll
xjp: qmn phl zdl vth
gjs: pht jnz vrg
bbs: kfj vjn hkv vhl
xvx: zgc
hmr: bnd nhz pfk
vmr: mzb
bkq: rqm
xdg: pst cpz qmx
fcl: sgq
fdp: sxf nmc fzj jgq
ctk: pxb prd bxp
gjd: xnq prk fxt
fzd: mtt
mgg: phc mcv hxs xlc
clv: krx jzt bmf gfn
vrg: gqv zmx zhr
ngx: zrg hsn vmx dzj
cmb: cnd
tnh: fdj tpq
kgc: jhf
lrh: hpc vbd cdk
lzj: dvz
tzs: hcb pbq kpx hns jhg ldm tbq jlz
lnz: kdp stl rmh
pxk: jpd gvk htr
zqz: rnf vkb dcs dff nbs xrs
trq: gtv qbr
rfk: hbr tqx
gqf: tqv xtq
pqc: zqm
pkk: qbp tbk xdn vnp
trf: kxt
btt: cjq mxg
xfb: pll
srk: cfs skm lqc hfc
rgf: mhm ggt xmj xnp zhx mln
ggt: rxs
dpd: mbj srf
pmg: gpb
mbs: cpz bxm tqs qln
hbr: sjc
znj: tgc bjc hhx
ttg: jrt";
}
