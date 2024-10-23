import { useState } from 'react';
import Button from 'react-bootstrap/Button';
import Modal from 'react-bootstrap/Modal';

function SwapModal(props: any) {

  return (
    <Modal
      {...props}
      backdrop="static"
      keyboard={false}
    >
      <Modal.Header closeButton>
        <Modal.Title>Confirm Swap</Modal.Title>
      </Modal.Header>
      <Modal.Body>
        <p>You are about to make a conversion of <strong>0.0345 BTC</strong> into <strong>3,453 STX</strong>.</p>
        <p><strong>0.0345 BTC</strong> -&gt; <span>tb1qeeqfngu5tnqfkxh3e0rdkj6m2ng2vqsr86lskq</span> (Pool Address)</p>
        <p>As soon as the BTC transaction reaches <strong>3 confirmations</strong> the transfer of
          <strong>3,453 STX</strong> will be initiated to the address provided by your Leather Wallet:
        </p>
        <p><strong>3,453 STX</strong> -&gt; <span>ST2JC8HK79X5QZW8ZXVA0Q6V1ZKAA3Q4VHZP29QAP</span> (Your Wallet Address)</p>
        <p>A fee of <strong>230 satoshis</strong> will be charged, please confirm if you agree.</p>
        <p>Do you confirm this transaction?</p>
      </Modal.Body>
      <Modal.Footer>
        <Button variant="secondary" onClick={props.onHide}>
          Close
        </Button>
        <Button variant="primary" onClick={props.onClick}>Understood</Button>
      </Modal.Footer>
    </Modal>
  );
}

export default SwapModal;