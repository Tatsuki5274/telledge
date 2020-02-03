$(function () {
	// 3候補リストに表示するデータを配列で準備
	var data = ['A', 'A+', 'ABAP', 'ABC', 'ABCL', 'ActionScript', 'Ada', 'Advanced Boolean Expression Language(ABEL)', 'Agena', 'AHDL', 'ALGOL', 'Alice', 'ash', 'APL', 'Apex', 'AppleScript', 'as', 'Atom', 'AutoIt', 'AutoLISP',
		'B', 'BASIC', 'BCPL', 'Befunge', 'BF-BASIC,n', 'Bioera', 'BLISS', 'Bluespec', 'Boo', 'BrainCrash', 'Brainfuck',
		'C', 'C#', 'C++', 'CAL', 'Caml', 'Cantata', 'CAP-X', 'CASL', 'Cecil', 'CFScript', 'Cg', 'Chapel', 'Chef', 'CHILL', 'Clipper', 'Clojure', 'CLU', 'Co-array Fortran', 'COBOL', 'CoffeeScript', 'Common Lisp', 'Component Pascal', 'Concurrent Clean', 'Concurrent Prolog', 'Constraint Handling Rules', 'CPL', 'csh', 'CUDA C / C++', 'Curl', 'Curry', 'Cω',
		'D', 'Dart', 'dBase', 'Delphi', 'Dylan',
		'ECMAScript', 'Eiffel', 'Elixir', 'Emacs Lisp', 'Enterprise Generation Language', 'Erlang', 'Escapade', 'Esterel', 'Euclid', 'Euphoria',
		'F*', 'F#', 'Factor', 'False', 'Fantom', 'Ferite', 'Ficl', 'Flavors', 'FlowDesigner', 'Forth', 'FORTRAN', 'Fortress', 'FoxPro',
		'GLSL', 'Go', 'Groovy', 'Guarded Horn Clauses',
		'Hack', 'HAL/S', 'Hardware Join Java', 'Haskell', 'Haxe', 'HDCaml', 'HLASM', 'HLSL', 'HML', 'HOLON', 'HSP', 'HQ9+', 'Hydra', 'HyperTalk',
		'Icon', 'ID', 'IDL', 'Inform', 'InScript', 'INTERCAL', 'Io', 'IPL', 'ISWIM',
		'J', 'Java', 'Jancy', 'Java FX Script', 'JavaScript', 'JHDL', 'JScript.NET', 'J#', 'JSX', 'Jolie', 'Julia',
		'KEMURI', 'Kent Recursive Calculator', 'Kuin', 'KL1', 'KornShell', 'Kotlin',
		'Lazy K', 'Lava', 'LFE', 'Limbo', 'Linda', 'Linden Scripting Language', 'Lingo', 'Lisaac', 'LISP', 'LOGO', 'Lola', 'LotusScript', 'Lua', 'Lucid', 'Lush', 'Lustre',
		'M言語', 'm4', 'Malbolge', 'Mana', 'Maple', 'MASM', 'MATLAB', 'Mathematica', 'Max', 'Mercury', 'Mesa', 'MIL / W', 'Mind', 'Mindscript', 'Miranda', 'Misa', 'MixJuice', 'ML', 'Modula - 2', 'Modula - 3', 'MONAmona', 'Mops', 'MQL4', 'MQL5', 'MSIL', 'MyHDL',
		'Napier88', 'NASM', 'Nemerle', 'Nim', 'Noop', 'NScripter',
		'O', 'Oberon', 'Oberon - 2', 'Object Pascal', 'Object REXX', 'Object Tcl', 'Objective-C', 'Objective Caml', 'Occam', 'Ook!', 'OpenOffice.org Basic', 'OPS', 'Oz',
		'P′', 'Pacbase', 'PALASM', 'PARLOG', 'Pascal', 'PBASIC', 'PCN', 'Perl', 'PHP', 'Pic', 'Piet', 'Pike', 'pine', 'PL / 0', 'PL / I', 'Planner', 'pnuts', 'Pony', 'PostScript', 'PowerBuilder', 'PowerShell', 'Processing', 'Prograph CPX', 'Prolog', 'Pure Data',
		'PureScript', 'PWCT', 'Pxem', 'Python',
		'QtScript', 'Quorum',
		'R', 'Racket', 'REALbasic', 'REBOL', 'REXX', 'RHDL', 'Ring', 'RPG', 'RPL', 'Ruby', 'Ruby', 'Rust',
		'SAL', 'SAS', 'Sather', 'Scala', 'Scheme', 'Scratch', 'Seed7', 'Self', 'SFL', 'sh', 'Shakespeare', 'Short Code', 'Simula', 'Simulink', 'SISAL',
		'SKILL', 'SLIP', 'Smalltalk', 'SMILEBASIC', 'SNOBOL', 'SPARK', 'Squeak', 'Squirrel', 'SPSS', 'Standard ML', 'Stata', 'superC', 'Swift', 'SystemC', 'SystemVerilog',
		't3x', 'TAL', 'Telescript', 'TeX', 'Text Executive Programming Language', 'Tcl', 'tcsh', 'Tenems', 'TL / I', 'Tonyu System', 'TTS', 'TTSneo', 'Turing', 'TypeScript',
		'Unified Parallel C', 'Unlambda', 'UnrealScript', 'VBScript', 'Visual Basic', 'Visual Basic.NET', 'Visual C.NET', 'Visual C++ .NET', 'Visual C# .NET', 'Visual Studio', 'Verilog HDL', 'VHDL', 'Viscuit', 'Vala', 'V', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '',
		'Whirl', 'Whitespace', 'WICS', 'WMLScript', 'Wyvern',
		'X10', 'XQuery', 'XSLT', 'zsh', 'ドリトル', 'なでしこ', 'ひまわり', '秀丸マクロ', 'プロデル', 'プログレスII']
	// 2オートコンプリート機能を適用
	$('#txtKeywd').autocomplete({
		source: data,
		autoFocus: true,
		delay: 200,
		minLength: 2
	});
});