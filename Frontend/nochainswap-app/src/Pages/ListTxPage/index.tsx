import Table from 'react-bootstrap/Table';
import Card from 'react-bootstrap/Card';
import Col from 'react-bootstrap/Col';
import Row from 'react-bootstrap/Row';
import Container from 'react-bootstrap/esm/Container';
import { MouseEvent, MouseEventHandler, useContext, useEffect, useState } from 'react';
import TxContext from '../../Contexts/Transaction/TxContext';
import TxInfo from '../../DTO/Domain/TxInfo';
import Modal from 'react-bootstrap/Modal';
import Button from 'react-bootstrap/esm/Button';

export default function ListTxPage() {

    const [showModal, setShowModal] = useState<boolean>(false);

    const txContext = useContext(TxContext);
    useEffect(() => {
        txContext.loadListAllTx().then((ret) => {
            if (!ret.sucesso) {
                alert(ret.mensagemErro);
            }
        });
    }, []);

    const txClickHandler = (e: any, item: TxInfo) => {
        e.preventDefault();
        txContext.setTxInfo(item);
        txContext.loadTxLogs(item.txid).then((ret) => {
            if (!ret.sucesso) {
                alert(ret.mensagemErro);
            }
        });
        setShowModal(true);
        //alert("hello");
    };

    return (
        <Container>
            <Modal
                show={showModal}
                size="lg"
                onHide={() => { setShowModal(false) }}
                backdrop="static"
                keyboard={false}
            >
                <Modal.Header closeButton>
                    <Modal.Title>Transaction {txContext.txInfo?.txtype} #{txContext.txInfo?.txid}</Modal.Title>
                </Modal.Header>
                <Modal.Body>
                    <dl className="row">
                        <dt className="col-sm-3">Status</dt>
                        <dd className="col-sm-9">{txContext.txInfo?.status}</dd>
                        <dt className="col-sm-3">{txContext.txInfo?.inttype == 1 ? "BTC Address" : "STX Address"}</dt>
                        <dd className="col-sm-9"><a href={
                            txContext.txInfo?.inttype == 1 ?
                                txContext.txInfo?.btcaddressurl :
                                txContext.txInfo?.stxaddressurl
                        } target="_blank">{
                                txContext.txInfo?.inttype == 1 ?
                                    txContext.txInfo?.btcaddress :
                                    txContext.txInfo?.stxaddress
                            }</a></dd>
                        <dt className="col-sm-3">{
                            txContext.txInfo?.inttype == 1 ? "BTC TxID" : "STX TxID"
                        }</dt>
                        <dd className="col-sm-9"><a href={
                            txContext.txInfo?.inttype == 1 ?
                                txContext.txInfo?.btctxidurl :
                                txContext.txInfo?.stxtxidurl
                        } target="_blank">{
                                txContext.txInfo?.inttype == 1 ?
                                    txContext.txInfo?.btctxid :
                                    txContext.txInfo?.stxtxid
                            }</a></dd>
                        <dt className="col-sm-3">{txContext.txInfo?.inttype == 1 ? "STX Address" : "BTC Address"}</dt>
                        <dd className="col-sm-9"><a href={
                            txContext.txInfo?.inttype == 1 ?
                                txContext.txInfo?.stxaddressurl :
                                txContext.txInfo?.btcaddressurl
                        } target="_blank">{
                                txContext.txInfo?.inttype == 1 ?
                                    txContext.txInfo?.stxaddress :
                                    txContext.txInfo?.btcaddress
                            }</a></dd>
                        {
                            (txContext.txInfo?.inttype == 1 ? txContext.txInfo?.stxtxid : txContext.txInfo?.btctxid) &&
                            <>
                                <dt className="col-sm-3">{
                                    txContext.txInfo?.inttype == 1 ? "STX TxID" : "BTC TxID"
                                }</dt>
                                <dd className="col-sm-9"><a href={
                                    txContext.txInfo?.inttype == 1 ?
                                        txContext.txInfo?.stxtxidurl :
                                        txContext.txInfo?.btctxidurl
                                } target="_blank">{
                                        txContext.txInfo?.inttype == 1 ?
                                            txContext.txInfo?.stxtxid :
                                            txContext.txInfo?.btctxid
                                    }</a></dd>
                            </>
                        }
                        <dt className="col-sm-3">Amounts</dt>
                        <dd className="col-sm-9">{
                            txContext.txInfo?.inttype == 1 ?
                                txContext.txInfo?.btcamount + " -> " + txContext.txInfo?.stxamount :
                                txContext.txInfo?.stxamount + " -> " + txContext.txInfo?.btcamount
                        }</dd>
                        <dt className="col-sm-3">Fees</dt>
                        <dd className="col-sm-9">{
                            txContext.txInfo?.inttype == 1 ?
                                txContext.txInfo?.btcfee + " -> " + txContext.txInfo?.stxfee :
                                txContext.txInfo?.stxfee + " -> " + txContext.txInfo?.btcfee
                        }</dd>
                        <dt className="col-sm-3">Dates</dt>
                        <dd className="col-sm-9">{
                            "Create at " + txContext.txInfo?.createat + ", latest udpate at " + txContext.txInfo?.updateat
                        }</dd>
                    </dl>
                    <hr />
                    <Table striped bordered hover size="sm">
                        <thead>
                            <tr>
                                <th scope="col">Date</th>
                                <th scope="col">Type</th>
                                <th scope="col">Message</th>
                            </tr>
                        </thead>
                        <tbody>
                            {
                                txContext.txLogs ?
                                    txContext.txLogs.map((log) => {
                                        return (
                                            <tr>
                                                <td scope="col">{log.date}</td>
                                                <td scope="col">{
                                                    (log.intlogtype == 1) &&
                                                    <span className="badge rounded-pill text-bg-info">Info</span>
                                                }
                                                    {
                                                        (log.intlogtype == 2) &&
                                                        <span className="badge rounded-pill text-bg-warning">Warning</span>
                                                    }
                                                    {
                                                        (log.intlogtype == 3) &&
                                                        <span className="badge rounded-pill text-bg-danger">Error</span>
                                                    }</td>
                                                <td scope="col">{log.message}</td>
                                            </tr>
                                        );
                                    })
                                    :
                                    txContext.loadingTxLogs ??
                                    <tr>
                                        <td colSpan={3}>
                                            <div className="d-flex justify-content-center">
                                                <div className="spinner-border" role="status">
                                                    <span className="visually-hidden">Loading...</span>
                                                </div>
                                            </div>
                                        </td>
                                    </tr>
                            }
                        </tbody>
                    </Table>
                </Modal.Body>
                <Modal.Footer>
                    <Button variant="secondary" onClick={() => { setShowModal(false) }}>
                        Close
                    </Button>
                </Modal.Footer>
            </Modal>
            <Row>
                <Col md="8" className='offset-md-2'>
                    <Card>
                        <Card.Body>
                            <h1 className="text-center">Latest Swaps</h1>
                            <hr />
                            <Table striped bordered hover size="sm">
                                <thead>
                                    <tr>
                                        <th scope="col">Swap</th>
                                        <th scope="col">Wallet</th>
                                        <th scope="col">Latest Update</th>
                                        <th scope="col">Amount</th>
                                        <th scope="col">Status</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    {
                                        txContext.allTxInfo ?
                                            txContext.allTxInfo.map((item) => {
                                                let userAddr = ((item.inttype == 1) ? item.btcaddress : item.stxaddress);
                                                let userView = userAddr.substr(0, 6) + '...' + userAddr.substr(-4);
                                                return (

                                                    <tr>
                                                        <td scope="col"><a href="#" onClick={(e) => { txClickHandler(e, item) }}>{item.txtype}</a></td>
                                                        <td scope="col"><a href="#" onClick={(e) => { txClickHandler(e, item) }}>{userView}</a></td>
                                                        <td scope="col"><a href="#" onClick={(e) => { txClickHandler(e, item) }}>{item.updateat}</a></td>
                                                        <td scope="col"><a href="#" onClick={(e) => { txClickHandler(e, item) }}>{
                                                            ((item.inttype == 1) ? item.btcamount : item.stxamount) +
                                                            " -> " +
                                                            ((item.inttype == 1) ? item.stxamount : item.btcamount)
                                                        }</a></td>
                                                        <td scope="col"><a href="#" onClick={(e) => { txClickHandler(e, item) }}>{item.status}</a></td>
                                                    </tr>
                                                )
                                            })
                                            :
                                            txContext.loadingAllTxInfo ??
                                            <tr>
                                                <td colSpan={5}>
                                                    <div className="d-flex justify-content-center">
                                                        <div className="spinner-border" role="status">
                                                            <span className="visually-hidden">Loading...</span>
                                                        </div>
                                                    </div>
                                                </td>
                                            </tr>
                                    }
                                </tbody>
                            </Table>
                        </Card.Body>
                    </Card>
                </Col>
            </Row>
        </Container>
    );
}