﻿using DevToys.Tools.Helpers.SqlFormatter.Core;

namespace DevToys.Tools.Helpers.SqlFormatter.Languages;

internal sealed class StandardSqlFormatter : Formatter
{
    private static readonly string[] ReservedWords
        =
        {
            "ABS",
            "ALL",
            "ALLOCATE",
            "ALTER",
            "AND",
            "ANY",
            "ARE",
            "ARRAY",
            "AS",
            "ASENSITIVE",
            "ASYMMETRIC",
            "AT",
            "ATOMIC",
            "AUTHORIZATION",
            "AVG",
            "BEGIN",
            "BETWEEN",
            "BIGINT",
            "BINARY",
            "BLOB",
            "BOOLEAN",
            "BOTH",
            "BY",
            "CALL",
            "CALLED",
            "CARDINALITY",
            "CASCADED",
            "CASE",
            "CAST",
            "CEIL",
            "CEILING",
            "CHAR",
            "CHAR_LENGTH",
            "CHARACTER",
            "CHARACTER_LENGTH",
            "CHECK",
            "CLOB",
            "CLOSE",
            "COALESCE",
            "COLLATE",
            "COLLECT",
            "COLUMN",
            "COMMIT",
            "CONDITION",
            "CONNECT",
            "CONSTRAINT",
            "CONVERT",
            "CORR",
            "CORRESPONDING",
            "COUNT",
            "COVAR_POP",
            "COVAR_SAMP",
            "CREATE",
            "CROSS",
            "CUBE",
            "CUME_DIST",
            "CURRENT",
            "CURRENT_CATALOG",
            "CURRENT_DATE",
            "CURRENT_DEFAULT_TRANSFORM_GROUP",
            "CURRENT_PATH",
            "CURRENT_ROLE",
            "CURRENT_SCHEMA",
            "CURRENT_TIME",
            "CURRENT_TIMESTAMP",
            "CURRENT_TRANSFORM_GROUP_FOR_TYPE",
            "CURRENT_USER",
            "CURSOR",
            "CYCLE",
            "DATE",
            "DAY",
            "DEALLOCATE",
            "DEC",
            "DECIMAL",
            "DECLARE",
            "DEFAULT",
            "DELETE",
            "DENSE_RANK",
            "DEREF",
            "DESCRIBE",
            "DETERMINISTIC",
            "DISCONNECT",
            "DISTINCT",
            "DOUBLE",
            "DROP",
            "DYNAMIC",
            "EACH",
            "ELEMENT",
            "ELSE",
            "END",
            "END-EXEC",
            "ESCAPE",
            "EVERY",
            "EXCEPT",
            "EXEC",
            "EXECUTE",
            "EXISTS",
            "EXP",
            "EXTERNAL",
            "EXTRACT",
            "FALSE",
            "FETCH",
            "FILTER",
            "FLOAT",
            "FLOOR",
            "FOR",
            "FOREIGN",
            "FREE",
            "FROM",
            "FULL",
            "FUNCTION",
            "FUSION",
            "GET",
            "GLOBAL",
            "GRANT",
            "GROUP",
            "GROUPING",
            "HAVING",
            "HOLD",
            "HOUR",
            "IDENTITY",
            "IN",
            "INDICATOR",
            "INNER",
            "INOUT",
            "INSENSITIVE",
            "INSERT",
            "INT",
            "INTEGER",
            "INTERSECT",
            "INTERSECTION",
            "INTERVAL",
            "INTO",
            "IS",
            "JOIN",
            "LANGUAGE",
            "LARGE",
            "LATERAL",
            "LEADING",
            "LEFT",
            "LIKE",
            "LIKE_REGEX",
            "LN",
            "LOCAL",
            "LOCALTIME",
            "LOCALTIMESTAMP",
            "LOWER",
            "MATCH",
            "MAX",
            "MEMBER",
            "MERGE",
            "METHOD",
            "MIN",
            "MINUTE",
            "MOD",
            "MODIFIES",
            "MODULE",
            "MONTH",
            "MULTISET",
            "NATIONAL",
            "NATURAL",
            "NCHAR",
            "NCLOB",
            "NEW",
            "NO",
            "NONE",
            "NORMALIZE",
            "NOT",
            "NULL",
            "NULLIF",
            "NUMERIC",
            "OCTET_LENGTH",
            "OCCURRENCES_REGEX",
            "OF",
            "OLD",
            "ON",
            "ONLY",
            "OPEN",
            "OR",
            "ORDER",
            "OUT",
            "OUTER",
            "OVER",
            "OVERLAPS",
            "OVERLAY",
            "PARAMETER",
            "PARTITION",
            "PERCENT_RANK",
            "PERCENTILE_CONT",
            "PERCENTILE_DISC",
            "POSITION",
            "POSITION_REGEX",
            "POWER",
            "PRECISION",
            "PREPARE",
            "PRIMARY",
            "PROCEDURE",
            "RANGE",
            "RANK",
            "READS",
            "REAL",
            "RECURSIVE",
            "REF",
            "REFERENCES",
            "REFERENCING",
            "REGR_AVGX",
            "REGR_AVGY",
            "REGR_COUNT",
            "REGR_INTERCEPT",
            "REGR_R2",
            "REGR_SLOPE",
            "REGR_SXX",
            "REGR_SXY",
            "REGR_SYY",
            "RELEASE",
            "RESULT",
            "RETURN",
            "RETURNS",
            "REVOKE",
            "RIGHT",
            "ROLLBACK",
            "ROLLUP",
            "ROW",
            "ROW_NUMBER",
            "ROWS",
            "SAVEPOINT",
            "SCOPE",
            "SCROLL",
            "SEARCH",
            "SECOND",
            "SELECT",
            "SENSITIVE",
            "SESSION_USER",
            "SET",
            "SIMILAR",
            "SMALLINT",
            "SOME",
            "SPECIFIC",
            "SPECIFICTYPE",
            "SQL",
            "SQLEXCEPTION",
            "SQLSTATE",
            "SQLWARNING",
            "SQRT",
            "START",
            "STATIC",
            "STDDEV_POP",
            "STDDEV_SAMP",
            "SUBMULTISET",
            "SUBSTRING",
            "SUBSTRING_REGEX",
            "SUM",
            "SYMMETRIC",
            "SYSTEM",
            "SYSTEM_USER",
            "TABLE",
            "TABLESAMPLE",
            "THEN",
            "TIME",
            "TIMESTAMP",
            "TIMEZONE_HOUR",
            "TIMEZONE_MINUTE",
            "TO",
            "TRAILING",
            "TRANSLATE",
            "TRANSLATE_REGEX",
            "TRANSLATION",
            "TREAT",
            "TRIGGER",
            "TRIM",
            "TRUE",
            "UESCAPE",
            "UNION",
            "UNIQUE",
            "UNKNOWN",
            "UNNEST",
            "UPDATE",
            "UPPER",
            "USER",
            "USING",
            "VALUE",
            "VALUES",
            "VAR_POP",
            "VAR_SAMP",
            "VARBINARY",
            "VARCHAR",
            "VARYING",
            "WHEN",
            "WHENEVER",
            "WHERE",
            "WIDTH_BUCKET",
            "WINDOW",
            "WITH",
            "WITHIN",
            "WITHOUT",
            "YEAR",
        };

    private static readonly string[] ReservedTopLevelWords
        =
        {
            "ADD",
            "ALTER COLUMN",
            "ALTER TABLE",
            "CASE",
            "DELETE FROM",
            "END",
            "FETCH FIRST",
            "FETCH NEXT",
            "FETCH PRIOR",
            "FETCH LAST",
            "FETCH ABSOLUTE",
            "FETCH RELATIVE",
            "FROM",
            "GROUP BY",
            "HAVING",
            "INSERT INTO",
            "LIMIT",
            "ORDER BY",
            "SELECT",
            "SET SCHEMA",
            "SET",
            "UPDATE",
            "VALUES",
            "WHERE",
        };

    private static readonly string[] ReservedTopLevelWordsNoIndent
        =
        {
            "INTERSECT",
            "INTERSECT ALL",
            "INTERSECT DISTINCT",
            "UNION",
            "UNION ALL",
            "UNION DISTINCT",
            "EXCEPT",
            "EXCEPT ALL",
            "EXCEPT DISTINCT",
        };

    private static readonly string[] ReservedNewlineWords
        =
        {
            "AND",
            "ELSE",
            "OR",
            "WHEN",
            "JOIN",
            "INNER JOIN",
            "LEFT JOIN",
            "LEFT OUTER JOIN",
            "RIGHT JOIN",
            "RIGHT OUTER JOIN",
            "FULL JOIN",
            "FULL OUTER JOIN",
            "CROSS JOIN",
            "NATURAL JOIN",
        };

    protected override Tokenizer GetTokenizer()
    {
        return
            new Tokenizer(
                ReservedWords,
                ReservedTopLevelWords,
                ReservedNewlineWords,
                ReservedTopLevelWordsNoIndent,
                stringTypes: new[] { "\"\"", "N''", "''", "``", "[]" },
                openParens: new[] { "(", "CASE" },
                closeParens: new[] { ")", "END" },
                indexedPlaceholderTypes: new[] { '?' },
                namedPlaceholderTypes: Array.Empty<char>(),
                lineCommentTypes: new[] { "--" },
                specialWordChars: Array.Empty<string>());
    }
}
