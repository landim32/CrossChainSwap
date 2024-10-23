--
-- PostgreSQL database dump
--

-- Dumped from database version 17.0 (Debian 17.0-1.pgdg120+1)
-- Dumped by pg_dump version 17.0 (Debian 17.0-1.pgdg120+1)

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET transaction_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

--
-- Name: public; Type: SCHEMA; Schema: -; Owner: pg_database_owner
--

CREATE SCHEMA public;


ALTER SCHEMA public OWNER TO pg_database_owner;

--
-- Name: SCHEMA public; Type: COMMENT; Schema: -; Owner: pg_database_owner
--

COMMENT ON SCHEMA public IS 'standard public schema';


SET default_tablespace = '';

SET default_table_access_method = heap;

--
-- Name: transaction_logs; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.transaction_logs (
    log_id bigint NOT NULL,
    tx_id bigint NOT NULL,
    date timestamp without time zone NOT NULL,
    log_type integer DEFAULT 1 NOT NULL,
    message character varying(300)
);


ALTER TABLE public.transaction_logs OWNER TO postgres;

--
-- Name: transaction_logs_log_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.transaction_logs_log_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.transaction_logs_log_id_seq OWNER TO postgres;

--
-- Name: transaction_logs_log_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.transaction_logs_log_id_seq OWNED BY public.transaction_logs.log_id;


--
-- Name: transactions; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.transactions (
    tx_id bigint NOT NULL,
    type integer NOT NULL,
    btc_address character varying(64) NOT NULL,
    stx_address character varying(64) NOT NULL,
    create_at timestamp without time zone NOT NULL,
    update_at timestamp without time zone NOT NULL,
    status integer NOT NULL,
    btc_txid character(64),
    stx_txid character(64),
    btc_fee integer,
    stx_fee integer,
    btc_amount bigint,
    stx_amount bigint
);


ALTER TABLE public.transactions OWNER TO postgres;

--
-- Name: transactions_tx_nid_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.transactions_tx_nid_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.transactions_tx_nid_seq OWNER TO postgres;

--
-- Name: transactions_tx_nid_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.transactions_tx_nid_seq OWNED BY public.transactions.tx_id;


--
-- Name: users; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.users (
    user_id bigint NOT NULL,
    create_at timestamp with time zone NOT NULL,
    update_at timestamp with time zone NOT NULL,
    hash character varying(64),
    btc_address character varying(64) NOT NULL,
    stx_address character varying(64) NOT NULL
);


ALTER TABLE public.users OWNER TO postgres;

--
-- Name: users_user_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.users_user_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.users_user_id_seq OWNER TO postgres;

--
-- Name: users_user_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.users_user_id_seq OWNED BY public.users.user_id;


--
-- Name: transaction_logs log_id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.transaction_logs ALTER COLUMN log_id SET DEFAULT nextval('public.transaction_logs_log_id_seq'::regclass);


--
-- Name: transactions tx_id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.transactions ALTER COLUMN tx_id SET DEFAULT nextval('public.transactions_tx_nid_seq'::regclass);


--
-- Name: users user_id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.users ALTER COLUMN user_id SET DEFAULT nextval('public.users_user_id_seq'::regclass);


--
-- Data for Name: transaction_logs; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public.transaction_logs VALUES (1, 1, '2024-10-16 11:57:07.175711', 1, 'Transaction has 0,00010 BTC, Fee 0 and extimate 0,00010 STX.');
INSERT INTO public.transaction_logs VALUES (2, 1, '2024-10-16 12:00:38.330956', 1, 'BTC Transaction confirmed.');
INSERT INTO public.transaction_logs VALUES (3, 1, '2024-10-16 12:02:07.012629', 1, 'Transaction has 0,00010 BTC, Fee 3.232 and extimate 0,30507 STX.');
INSERT INTO public.transaction_logs VALUES (4, 1, '2024-10-16 12:02:10.563692', 3, 'An error occurred while sending the request.');


--
-- Data for Name: transactions; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public.transactions VALUES (1, 1, 'tb1qeeqfngu5tnqfkxh3e0rdkj6m2ng2vqsr86lskq', 'ST2JC8HK79X5QZW8ZXVA0Q6V1ZKAA3Q4VHZP29QAP', '2024-10-14 01:12:45.162802', '2024-10-14 01:12:45.162854', 12, 'b9969fd09c82dcbd6db1e1ec04bce6212effa923bf4c182d773f0352f693695a', NULL, 3232, NULL, 10000, 30506544);


--
-- Data for Name: users; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public.users VALUES (1, '2024-10-13 00:00:00+00', '2024-10-13 00:00:00+00', NULL, 'tb1qeeqfngu5tnqfkxh3e0rdkj6m2ng2vqsr86lskq', 'ST2JC8HK79X5QZW8ZXVA0Q6V1ZKAA3Q4VHZP29QAP');


--
-- Name: transaction_logs_log_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.transaction_logs_log_id_seq', 4, true);


--
-- Name: transactions_tx_nid_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.transactions_tx_nid_seq', 2, true);


--
-- Name: users_user_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.users_user_id_seq', 1, true);


--
-- Name: transactions pk_tx; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.transactions
    ADD CONSTRAINT pk_tx PRIMARY KEY (tx_id);


--
-- Name: transaction_logs pk_tx_log; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.transaction_logs
    ADD CONSTRAINT pk_tx_log PRIMARY KEY (log_id);


--
-- Name: users users_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.users
    ADD CONSTRAINT users_pkey PRIMARY KEY (user_id);


--
-- Name: transaction_logs fk_tx_log; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.transaction_logs
    ADD CONSTRAINT fk_tx_log FOREIGN KEY (tx_id) REFERENCES public.transactions(tx_id);


--
-- PostgreSQL database dump complete
--

